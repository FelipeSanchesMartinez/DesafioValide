using DesafioValide.Application.Requests.Entities;
using DesafioValide.Application.ViewModel;
using DesafioValide.Domain.Entities;
using DesafioValide.Application.Requests.Produtos;
using DesafioValide.Application.Queries.Produtos;
using DesafioValide.Domain.Interfaces;
using MediatR;
using AutoMapper;
using DesafioValide.Domain.Util;

namespace DesafioValide.Application.RequestHandlers
{
    public class ProdutoRequestHandlers : IRequestHandler<InserirProdutoResquest>,
                                          IRequestHandler<AtualizarProdutoRequest>,
                                          IRequestHandler<DeleteEntityByIdRequest<ProdutoRequest>>,
                                          IRequestHandler<ObterTodosProdutoPaginadoRequest,PaginationData<ProdutoViewModel>>,
                                          IRequestHandler<ObterProdutoPorNomePaginadoRequest, PaginationData<ProdutoViewModel>>,
                                          IRequestHandler<ObterProdutoPorCategoriaIdPaginadoRequest, PaginationData<ProdutoViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoRequestHandlers(IMapper mapper, IProdutoRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public Task Handle(InserirProdutoResquest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Produto>(request);
            _repository.Inserir(entity);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task Handle(AtualizarProdutoRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Produto>(request);
            _repository.Atualizar(request.Id!.Value, entity);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task Handle(DeleteEntityByIdRequest<ProdutoRequest> request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id!.Value);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task<PaginationData<ProdutoViewModel>> Handle(ObterTodosProdutoPaginadoRequest request, CancellationToken cancellationToken)
        {
            var produtos =  _repository.ObterTodosPaginado(request.Page, request.Limit);
            var data = _mapper.Map<List<ProdutoViewModel>>(produtos.Data);
            return Task.FromResult(new PaginationData<ProdutoViewModel>(data, produtos.Page, produtos.Limit, produtos.TotalRecords));
        }

        public Task<PaginationData<ProdutoViewModel>> Handle(ObterProdutoPorNomePaginadoRequest request, CancellationToken cancellationToken)
        {
            var produtos = _repository.ObterPorProdutoNomePaginado(request.Page, request.Limit, request.Name);
            var data = _mapper.Map<List<ProdutoViewModel>>(produtos.Data);
            return Task.FromResult(new PaginationData<ProdutoViewModel>(data, produtos.Page, produtos.Limit, produtos.TotalRecords));
        }

        public Task<PaginationData<ProdutoViewModel>> Handle(ObterProdutoPorCategoriaIdPaginadoRequest request, CancellationToken cancellationToken)
        {
            var produtos = _repository.ObterPorProdutoPorCategoriaIdPaginado(request.Page, request.Limit, request.CategoriaId);
            var data = _mapper.Map<List<ProdutoViewModel>>(produtos.Data);
            return Task.FromResult(new PaginationData<ProdutoViewModel>(data, produtos.Page, produtos.Limit, produtos.TotalRecords));
        }
    }
}
