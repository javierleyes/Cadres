using Cadres.Domain.Entity;
using Cadres.Infrastructure.Repository.Interface;
using Cadres.Service.Dto;
using Cadres.Service.Interface;

namespace Cadres.Service
{
    public class FrameService : IFrameService
    {
        private IRodRepository RodRepository { get; set; }
        public FrameService(IRodRepository rodRepository)
        {
            RodRepository = rodRepository;
        }

        public FrameGetPriceOutputDataContract GetPriceFrameOutputDataContract(FrameGetPriceInputDataContract frameInput)
        {
            // validate

            Rod rod = RodRepository.GetById(frameInput.IdRod);

            // assembler
            Frame frame = new Frame(frameInput.Width, frameInput.Large, rod);

            return new FrameGetPriceOutputDataContract() { Width = frameInput.Width, Large = frameInput.Large, Price = frame.Price, RodName = rod.Name };
        }

    }
}
