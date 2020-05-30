namespace Animation
{
    public interface IParticleFactory
    {
        IParticle CreateParticle(int x, int y, double charge, double weight, bool pozitivCharge);
    }
}