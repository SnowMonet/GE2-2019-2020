using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class NoiseSystem : SystemBase
{
    float offset = 0;
    public static float Map(float value, float r1, float r2, float m1, float m2)
    {
        float dist = value - r1;
        float range1 = r2 - r1;
        float range2 = m2 - m1;
        return m1 + ((dist / range1) * range2);
    }
    protected override void OnUpdate()
    {
        // Local variable captured in ForEach
        float dT = Time.DeltaTime;
        this.offset += Time.DeltaTime;
        float offset = this.offset;
        float noiseScale = Spawner.Instance.noiseScale;

        float lower = Spawner.Instance.lower;
        float upper = Spawner.Instance.upper;

        Entities
            .WithName("FlowField_Job")
            .ForEach(
                (ref NonUniformScale s, ref Translation p, ref Flow f) =>
                {
                    float scale = Map(Perlin.Noise((p.Value.x + offset) * noiseScale, (p.Value.y + offset) * noiseScale, (p.Value.z + offset) * noiseScale), -1, 1, lower, upper);
                    s = new NonUniformScale() { Value = scale };

                    /*
                    p = new Translation()
                    {
                        // dT is a captured variable
                        Value = new float3(0, 0, 0)
                    };
                    */
                }
            )
            .Schedule();
    }
}