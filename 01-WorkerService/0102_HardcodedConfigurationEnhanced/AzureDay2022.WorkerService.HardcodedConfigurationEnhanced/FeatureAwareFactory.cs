public enum FeatureFlags
{
    LogTime
}

public interface IFeatureAwareFactory
{
    public Task<bool> EnrichLogMesssageWithTimestamp { get; }
}

public class FeatureAwareFactory : IFeatureAwareFactory
{
    private readonly IFeatureManager featureManager;

    public FeatureAwareFactory(IFeatureManager featureManager)
    {
        this.featureManager = featureManager;
    }

    public Task<bool> EnrichLogMesssageWithTimestamp => featureManager.IsEnabledAsync(nameof(FeatureFlags.LogTime));
}