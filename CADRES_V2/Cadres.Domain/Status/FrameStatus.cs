using System.ComponentModel;

namespace Cadres.Domain.Status
{
    public class FrameStatus
    {
        public enum FrameMakingStatus
        {
            [Description("Pendiente")]
            Pending = 0,

            [Description("Listo")]
            Ready = 1,

            [Description("Sin materiales")]
            WithoutMaterials = 2,
        }
    }
}
