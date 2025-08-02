import './TextArea.css'

import React from "react"

export default props => {
    return (
        <div className="elemForm">
            <label htmlFor={props.nome} className="label"> {props.nome} </label>
            <textarea
                name={props.nome}
                id={props.nome}
                className={props.classe}
                placeholder={props.etiqueta}
                value={props.valor}
                onChange={(e) => props.setValor(e.target.value)}
            />
        </div>
    )
}