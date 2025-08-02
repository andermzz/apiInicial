import './Select.css'

import React from "react";

export default (props) => {
    return (
        <div className="elemForm">
            <label htmlFor={props.nome} className="label"> {props.nome} </label>

            <select name={props.nome} id={props.nome} className={props.classe} value={props.valor} onChange={(e) => props.setValor(e.target.value)}>
                <option value>Selecione uma opção</option>

                {
                    props.itens.map((elem, i) => (
                        <option key={i} value={elem.id}>{elem.item}</option>
                    ))
                }

            </select>

        </div>
    )
}