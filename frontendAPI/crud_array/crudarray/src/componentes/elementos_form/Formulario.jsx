import './Formulario.css'

import React, { useState } from "react";

import Input from "./Input";
import Select from './Select';
import TextArea from './TextArea';

export default (props) => {
    const [id, setId] = useState(0)
    const [descricao, setDescricao] = useState('')
    const [detalhe, setDetalhe] = useState('')
    const [valorUnitario, setValorUnitario] = useState()
    const [categoria, setCategoria] = useState()
    const [itensSelect, setItensSelect] = useState([
        {
            id: 1,
            item: 'A'
        },
        {
            id: 2,
            item: 'B'
        },
        {
            id: 3,
            item: 'C'
        },
        {
            id: 4,
            item: 'D'
        },
        {
            id: 5,
            item: 'E'
        },

    ])

    const item = {
        idItem: parseInt(Math.random() * (100 * 1) - 1),
        descricao: descricao,
        detalhe: detalhe,
        valorUnitario: valorUnitario,
        categoria: categoria,
        status: true
    }

    const enviarDados = (e) => {
        e.preventDefault()

        props.adicionarItem(item)

        setId(0)
        setDescricao('')
        setDetalhe('')
        setValorUnitario('')
        setCategoria('')

    }

    const valorSelect = (e) => {
        

    }

    return (
        <div className="form">
            <h2>ADCIONAR ITEM </h2>
            <form onSubmit={enviarDados} >
                <Input tipo='text' nome='descricao' classe='Input' etiqueta='Informe a descrição do Item' valor={descricao} setValor={setDescricao} />

                <TextArea nome='detalhe' classe='TextArea' largura={80} altura={30} etiqueta='Informe os detalhes do Item' valor={detalhe} setValor={setDetalhe} />

                <Input tipo='number' nome='valorUnitario' classe='Input' etiqueta='Informe o valor unitário do Item' valor={valorUnitario} setValor={setValorUnitario} />

                <Select nome='categoria' classe='Select' valor={categoria} setValor={setCategoria} itens={itensSelect} />

                <button> Adcionar </button>

            </form>
        </div>
    )
}