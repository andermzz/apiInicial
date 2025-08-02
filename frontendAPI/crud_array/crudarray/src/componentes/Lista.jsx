import './Lista.css'

import React, { useState } from "react";

import Formulario from "./elementos_form/Formulario";

export default props => {

    const [lista, setLista] = useState([])

    const addItem = (objItem) => {

        const itens = [...lista, objItem]

        setLista(itens)
    }

    const removerItem = (id) => {
        if (window.confirm('DESEJA REMOVER O ITEM?')) {
            const arrayFiltro = [...lista]

            const itensFiltrados = arrayFiltro.filter((elem) => elem.idItem !== id ? elem : null)

            setLista(itensFiltrados)
        }
    }

    const alteraStatus = (id) => {
        if (window.confirm('DESEJA ALTERAR O STATUS DO ITEM?')) {
            const arrayFiltro = [...lista]

            arrayFiltro.map((elem) => elem.idItem === id ? elem.status = !elem.status : elem)

            setLista(arrayFiltro)
        }
    }

    return (
        <>

            <Formulario adicionarItem={addItem} />

            <div className="lista">

                {
                    lista.map((elem, i) => (
                        <div className='item' key={i}>
                            <div className='itemDescricao' style={{ textDecoration: !elem.status ? 'line-through' : '' }}>
                                <span> {elem.idItem} </span>
                                <span> {elem.descricao} </span>
                                <span> {elem.detalhe} </span>
                                <span> R$ {parseFloat(elem.valorUnitario).toFixed(2).replace('.', ',')}</span>
                                <span> {elem.categoria}</span>
                                <span><button className='btnLista' onClick={() => alteraStatus(elem.idItem)}> A </button> </span>
                                <span><button className='btnLista' onClick={() => removerItem(elem.idItem)}> R </button> </span>
                            </div>
                        </div>
                    ))
                }

            </div>

        </>
    )
}