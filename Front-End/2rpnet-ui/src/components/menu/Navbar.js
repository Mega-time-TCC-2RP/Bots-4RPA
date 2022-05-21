import React from 'react'
import { Link } from 'react-router-dom'
import '../../assets/css/components/navbar.css'


// Icons from react-icons
import * as FaIcons from 'react-icons/fa'
import * as ImIcons from 'react-icons/im'
import * as AiIcons from 'react-icons/ai'
import * as RiIcons from 'react-icons/ri'
import * as BsIcons from 'react-icons/bs'
import * as HiIcons from 'react-icons/hi'

import { useNavigate } from 'react-router-dom';



//logo
import Logo from '../../assets/img/logo2RPbranco.png'
// import Logo from '../../assets/img/logo2RP.png'
import Profile from '../../assets/img/profile.jpg'

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { parseJwt } from '../../services/auth'

function Navbar() {

  function click() {
    let sidebar = document.querySelector('.sidebar')
    sidebar.classList.toggle('active')
  }

  // const delay = ms => new Promise(res => setTimeout(res, ms))
  const signout = () => {

    localStorage.removeItem('2rp-chave-autenticacao')
    history('/login')
    window.location.reload()
    return true
  }



  let history = useNavigate();
  // btn.onclick = function(){
  //   sidebar.classList.toggle('active')
  // }
  // onClick={sidebar.classList.toggle('active')}

  return (

    <div className='sidebar'>
      <ToastContainer />
      <div className='logo_content'>
        <img className='logo' src={Logo} alt="Logo 2RPnet" />
        <FaIcons.FaBars className='btn' onClick={click} />
      </div>
      <ul className='nav_list'>
        <li>
          <Link to="/" className='Link'>
            <ImIcons.ImHome3 className='icon2' alt="botão página inicial" />
            <span className='Links_name' alt="botão página inicial">Home</span>
          </Link>
        </li>
        <li>
          <Link to="/guide" className='Link'>
            <RiIcons.RiGuideFill className='icon2' alt="botão guias" />
            <span className='Links_name' alt="botão guias">Guias</span>
          </Link>
        </li>
        {/* {parseJwt().Role !== '1' && parseJwt().Role !== '0' ?
          <li>
            <Link to="/skinShop" className='Link'>
              <FaIcons.FaTshirt className='icon2' alt="botão loja" />
              <span className='Links_name' alt="botão loja de skins">Skins</span>
            </Link>
          </li>
          : null
        } */}
        {parseJwt().Role !== '1' && parseJwt().Role !== '0' ?
          <li>
            <Link to="/marketplace" className='Link'>
              <RiIcons.RiShoppingBagFill className='icon2' alt="botão loja" />
              <span className='Links_name' alt="botão loja">Loja</span>
            </Link>
          </li>
          : null
        }
        {parseJwt().Role !== '1' && parseJwt().Role !== '0' ?
          <li>
            <Link to="/quests" className='Link'>
              <FaIcons.FaTasks className='icon2' alt="botão tarefas" />
              <span className='Links_name' alt="botão tarefas">Tarefas</span>
            </Link>
          </li>
          : null
        }
        {parseJwt().Role !== '1' && parseJwt().Role !== '0' ?
          <li>
            <Link to="/assistant" className='Link'>
              <FaIcons.FaRobot className='icon2' alt="botão assistentes" />
              <span className='Links_name' alt="botão assistentes">Assistentes</span>
            </Link>
          </li>
          : null
        }
        <li>
          <Link to="/social" className='Link'>
            <AiIcons.AiFillMessage className='icon2' alt="botão fórum social" />
            <span className='Links_name' alt="botão fórum social">Social</span>
          </Link>
        </li>
        <li>
          <Link to="/config" className='Link'>
            <BsIcons.BsFillGearFill className='icon2' alt="botão configurações" />
            <span className='Links_name' alt="botão configurações">Configurações</span>
          </Link>
        </li>

      </ul>
      <div className='profile_content'>
        <div className='profile'>
          <div className='profile_details'>
            <div className='name_job'>
              <span className='name' onClick={signout}>Logout</span>
            </div>
          </div>
              <HiIcons.HiOutlineLogout id='log_out' onClick={signout} />
        </div>
      </div>
    </div>


  );


}
export default Navbar;