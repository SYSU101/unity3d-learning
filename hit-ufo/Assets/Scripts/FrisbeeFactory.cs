using System.Collections.Generic;

public class FrisbeeFactory
{
    private Queue<FrisbeeRenderer> pool;
    private Configs configs;
    private ResourceMgr resources;
    private Models models;

    public FrisbeeFactory(Configs configs, Models models, ResourceMgr resources)
    {
        this.pool = new Queue<FrisbeeRenderer>();
        this.configs = configs;
        this.resources = resources;
        this.models = models;
    }

    public FrisbeeRenderer Produce()
    {
        FrisbeeRenderer product;
        if (this.pool.Count > 0)
        {
            product = this.pool.Peek();
            this.pool.Dequeue();
        } else
        {
            product = new FrisbeeRenderer(this.configs, this, this.models, new Stop(), this.resources);
        }
        product.recycled = false;
        return product;
    }
    
    public void Recycle(FrisbeeRenderer product)
    {
        if (!product.recycled)
        {
            product.Move = new Stop();
            product.MoveTo(this.configs.DefaultFrisbeePos);
            product.recycled = true;
            this.pool.Enqueue(product);
        }
    }
}
