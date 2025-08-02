import './Conteudo.css'

import React from "react"

export default props => {
    return (
        <section className="Conteudo">
            {props.children}
        </section>
    )
}