import './elementos_form/Formulario.css'

import React, { useState } from "react";
import { useNavigate } from 'react-router-dom'

import Input from "./elementos_form/Input";

export default () => {

    const endPoint = 'https://localhost:7166/hamburgueria/pessoa'

    const [nome, setNome] = useState('')
    const [idade, setIdade] = useState(0)
    const [renda, setRenda] = useState(0.0)
    const navegacao = useNavigate()

    /*const pessoa = {
        nome: nome,
        idade: idade,
        renda: renda,
    }*/

    const enviarDados = (e) => {
        e.preventDefault()

        fetch(endPoint, {
            method: 'POST',
            body: JSON.stringify({
                nome: nome,
                idade: idade,
                renda: renda,
            }),
            headers: {
                'Content-type': 'application/json',
            },
        }).then((resposta) => resposta.json())
            .then((info) => console.log(info))
            .catch((error) => console.log(error))

        navegacao('/listapessoas')
    }

    return (
        <>

            <div className="form">
                <h2>Cadastro Pessoa </h2>

                <form onSubmit={enviarDados}>
                    <Input tipo='text' nome='nome' classe='Input'
                        etiqueta='Informe o nome' valor={nome} setValor={setNome} />

                    <Input tipo='text' nome='idade' classe='Input' etiqueta='Informe a idade' valor={idade} setValor={setIdade} />

                    <Input tipo='text' nome='renda' classe='Input' etiqueta='Informe a renda' valor={renda} setValor={setRenda} />

                    <button> Cadastrar </button>
                </form>
            </div>

        </>
    )
}