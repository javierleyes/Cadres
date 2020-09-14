using Cadres.Service.Dto;

namespace Cadres.Service.Interface
{
    public interface IFrameService
    {
        FrameGetPriceOutputDataContract GetPriceFrameOutputDataContract(FrameGetPriceInputDataContract frameInput);
    }
}
