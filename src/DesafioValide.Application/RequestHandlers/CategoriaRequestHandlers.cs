using AutoMapper;
using DesafioValide.Application.Queries.Categorias;
using DesafioValide.Application.Requests.Categorias;
using DesafioValide.Application.Requests.Entities;
using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Entities;
using DesafioValide.Domain.Interfaces;
using DesafioValide.Domain.Util;
using MediatR;

namespace DesafioValide.Application.RequestHandlers
{
    public class CategoriaRequestHandlers : IRequestHandler<InserirCategoriaRequest>,
                                            IRequestHandler<AtualizarCategoriaRequest>,
                                            IRequestHandler<DeleteEntityByIdRequest<CategoriaRequest>>,
                                            IRequestHandler<ObterCategoriaPaginedRequest, PaginationData<CategoriaViewModel>>,
                                            IRequestHandler<ObterTodasCategoriaRequest, List<CategoriaViewModel>>
        
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaRequestHandlers(IMapper mapper, ICategoriaRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task Handle(InserirCategoriaRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Categoria>(request);
            _repository.Inserir(entity);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task Handle(AtualizarCategoriaRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Categoria>(request);
            _repository.Atualizar(request.Id!.Value, entity);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task Handle(DeleteEntityByIdRequest<CategoriaRequest> request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id!.Value);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<PaginationData<CategoriaViewModel>> Handle(ObterCategoriaPaginedRequest request, CancellationToken cancellationToken)
        {
            var categoria = _repository.ObterTodosPaginado(request.Page, request.Limit);
            var data = _mapper.Map<List<CategoriaViewModel>>(categoria.Data);
            return Task.FromResult(new PaginationData<CategoriaViewModel>(data, categoria.Page, categoria.Limit, categoria.TotalRecords));
        }

        public Task<List<CategoriaViewModel>> Handle(ObterTodasCategoriaRequest request, CancellationToken cancellationToken)
        {
            var categoria = _repository.ObterTodos();
            return Task.FromResult(_mapper.Map<List<CategoriaViewModel>>(categoria));
        }
    }
}