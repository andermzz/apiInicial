import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import Pagina from './layout/Pagina'
import Lista from './Lista'
import Home from './Home'
import Erro from './Erro'
import ListaPessoas from './ListaPessoas'
import CadastroPessoa from './CadastroPessoa'


export default () => {
    return(
        <>
            <Router>
                <Routes>
                    <Route path='/' element={<Pagina/>}>
                        <Route>
                            <Route index element={<Home/>}/>
                            <Route path='/lista' element={<Lista/>}/>
                            <Route path='/listapessoas' element={<ListaPessoas/>}/>
                            <Route path='/cadastropessoa' element={<CadastroPessoa/>}/>
                            <Route path='*' element={<Erro/>}/>
                        </Route>
                    </Route>
                </Routes>
            </Router>
        </>
    )
}