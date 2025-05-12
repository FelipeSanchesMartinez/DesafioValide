using DesafioValide.Domain.Interfaces;
using DesafioValide.Domain.Notifications;
using MediatR;

namespace DesafioValide.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLContext _sqlContext;
        private readonly IMediator _mediator;
        public UnitOfWork(SQLContext sqlContext, IMediator mediator)
        {
            _sqlContext = sqlContext ?? throw new ArgumentNullException(nameof(sqlContext));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public bool Commit()
        {
            try
            {
                return _sqlContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _mediator.Publish(new DomainNotification(nameof(UnitOfWork), $"Ocorreu um erro ao tentar gravar alterações no banco de dados. Erro:{ex.Message}"));
                return false;
            }
        }
    }
}
