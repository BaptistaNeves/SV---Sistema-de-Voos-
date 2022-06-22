using FluentValidation;
using SV.Application.InputModels.Voos;

namespace SV.Application.Validations.Voos
{
    public class VooValidation : AbstractValidator<VooInputModel>
    {
        public VooValidation()
        {
            RuleFor(v => v.Descricao)
                .NotEmpty().WithMessage("Informe uma Descrição/Nome para este voo!")
                .MinimumLength(5).WithMessage("A descrição deve ter no minimo 5 caracteres!");

            RuleFor(v => v.Imagem)
                .NotEmpty().WithMessage("Seleccione uma imagem para o voo!");

            RuleFor(v => v.Piloto)
                .NotEmpty().WithMessage("Seleccione o piloto deste voo!");

            RuleFor(v => v.CoPiloto)
                .NotEmpty().WithMessage("Seleccione o co-piloto deste voo!");


            RuleFor(v => v.TipoDeVooId)
                .NotEmpty().WithMessage("Seleccione o tipo de voo!");

            RuleFor(v => v.AeronaveId)
                .NotEmpty().WithMessage("Seleccione a aeronave deste voo");

            RuleFor(v => v.AeroportoDeOrigem)
                .NotEmpty().WithMessage("Seleccione o aeroporto de origem deste voo!");

            RuleFor(v => v.AeroportoDestino)
                .NotEmpty().WithMessage("Seleccione o aeroporto de destini deste voo");

            RuleFor(v => v.AeroportoDeOrigem)
                .NotEqual(v => v.AeroportoDestino).WithMessage("O Aeroporto de Origem não pode ser igual ao Aeroporto de Destino!");

            RuleFor(v => v.DataDePartida)
                .NotEmpty().WithMessage("Informe a data de partida deste voo!");

            RuleFor(v => v.HoraDePartida)
                .NotEmpty().WithMessage("Informe a hora de partida deste voo!");

            RuleFor(v => v.PrevisaoDeChegada)
                .NotEmpty().WithMessage("Informe a previsão de chegada deste voo!");

            RuleFor(v => v.PrevisaoDeChegadaAoDestino)
                .NotEmpty().WithMessage("Informe a previsão de chegada ao destino final deste voo!");
        }
    }
}
