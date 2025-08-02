import './Cabecalho.css'

import { Link } from 'react-router-dom'
import React from "react"


export default () => {
    return (
        <header className="Cabecalho">
            <div id="logo">
                <Link to={'/'}>
                    LOGO
                </Link>

            </div>
            <nav className="menu">
                <ul>
                    <li> <Link to={'/lista'}> Lista </Link> </li>
                    <li> <Link to={'/listapessoas'}> Lista Pessoas </Link> </li>
                    <li> <Link to={'/cadastropessoa'}> Cadastro Pessoa </Link>  </li>
                    <li> Menu 04 </li>
                </ul>
            </nav>
        </header>
    )

}
