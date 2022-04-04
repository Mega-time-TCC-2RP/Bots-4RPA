import React from 'react';
import ReactDOM from 'react-dom';

import {
  Route,
  BrowserRouter as Router,
  Routes,
  Navigate,
} from 'react-router-dom';

import './assets/css/components/button.css'
import './index.css';

import Navbar from './components/menu/Navbar'
import Home from './pages/home/';
import Login from './pages/login/';
import Guide from './pages/guide/';
import Marketplace from './pages/marketplace/';
import MyProcesses from './pages/myProcesses/';
import Social from './pages/social/index';
import TaskCalendar from './pages/taskCalendar';
import TaskKanban from './pages/taskKanban';

import Config from './pages/config/';

import NotFound from './pages/notFound/';
import LandingPage from './pages/landingPage/landingPage';

const routing = (
  <Router>
    <div>
      <Routes>
        <Route exact path="/" element={<Home/>} /> {/* Home */}
        <Route path="/landingPage" element={<LandingPage/>} />
        <Route path="/login" element={<Login/>} /> {/* Login */}
        <Route path="/guide" element={<Guide/>} /> {/* Guide */}
        <Route path="/marketplace" element={<Marketplace/>} /> {/* Marketplace */}
        <Route path="/myprocesses" element={<MyProcesses/>} /> {/* MyProcesses */}
        <Route path="/social" element={<Social/>} /> {/* Social */}
        <Route path="/taskcalendar" element={<TaskCalendar/>} /> {/* Task Calendar */}
        <Route path="/taskkanban" element={<TaskKanban/>} /> {/* Task Kanban */}

        <Route path="/config" element={<Config/>} /> {/* Configuration */}
     
        <Route path="/notFound" element={<NotFound/>} /> {/* Not Found */}
        <Route path="*" element={<Navigate to="notFound"/>} /> {/*Redireciona para Not Found caso não encontre nenhuma rota*/}
      </Routes>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));


