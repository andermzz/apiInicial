import './Pagina.css'

import { Outlet } from 'react-router-dom'
import React from "react"

import Cabecalho from "./Cabecalho"
import Conteudo from "./Conteudo"
import Rodape from "./Rodape"


export default () => {

    return (
        <>
            <Cabecalho />

            <Conteudo>
                <Outlet />
            </Conteudo>

            <Rodape />
        </>
    )
}