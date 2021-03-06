import "../../assets/css/style.css"
import VLibras from '@djpfs/react-vlibras'
import '../../assets/css/pages/notFound.css'
import { Link } from 'react-router-dom'



//components
import Footer from '../../components/footer/footer'
import Navbar from '../../components/menu/Navbar'

//img
import notFound from '../../assets/img/notFound.png'


const NotFound = () => {
  //verificar se o usuario está registrado(token)

  return (
    <div>
      <Navbar/>
      <VLibras/>
      <div className="notfoundimg">
      <img className="notfoundimg" src={notFound} alt="imagem de error 404"/>
      <h1 className="test">Página não encontrada :(</h1>
      <p className="p pNotfound">Parece que essa página não existe ou há algum erro de conexão.</p>
      <p className="p pNotfound">Por favor, volte e tente novamente.</p>
      <Link to="/">
      <button className='button buttonNotfound'>Voltar</button>
      </Link>
      </div>
      <div>
      </div>
      <Footer/>
    </div>

  );
}

export default NotFound;