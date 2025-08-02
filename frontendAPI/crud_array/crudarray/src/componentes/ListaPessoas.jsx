import './Lista.css'

import React, { useEffect, useState } from "react"

export default () => {

    const endPoint = 'https://localhost:7166/hamburgueria/pessoa'

    const [lista, setLista] = useState([])

    useEffect(() => {
        async function carregaPessoas() {
            const resposta = await fetch(endPoint)
            const dados = await resposta.json()
            setLista(dados)
        }

        carregaPessoas()
    }, [])

    return (
        <>
            <h2>Lista Pessoas </h2>

            <div className="lista">

                {
                    lista.map((elem, i) => (

                        <div className='item' key={i}>
                            <div className='itemDescricao'>
                                <span> {elem.idpessoa} </span>
                                <span> {elem.nome} </span>
                                <span> {elem.idade} </span>
                                <span> {elem.statuspessoa} </span>
                                <span> R$ {parseFloat(elem.renda).toFixed(2).replace('.', ',')}</span>
                                <span><button className='btnLista' onClick={() => elem.idpessoa}> A </button> </span>
                                <span><button className='btnLista' onClick={() => elem.idpessoa}> R </button> </span>
                            </div>
                        </div>

                    ))
                }

            </div>

        </>
    )
}