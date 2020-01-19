using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhaApp.Apresentacao.ViewModels;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;

namespace MinhaApp.Apresentacao.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, IMapper mapper, IFornecedorRepositorio fornecedorRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepositorio.ObterProdutosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);
            await _produtoRepositorio.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction(nameof(Index));
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) View(produtoViewModel);

            await _produtoRepositorio.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoRepositorio.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepositorio.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepositorio.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepositorio.ObterTodos());
            return produto;
        }
    }
}
