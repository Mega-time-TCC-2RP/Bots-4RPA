// Componetizacoes
import Navbar from '../../components/menu/Navbar'
import Header from '../../components/header/header.js'

//libras
import VLibras from '@djpfs/react-vlibras'


// CSS
import "../../assets/css/style.css"
import "../../assets/css/pages/taskCalendar.css"
import "../../assets/css/components/fonts.css"
import "../../assets/css/components/button.css"
import { useEffect } from 'react'

function App() {

  const day = () => {
    const date = new Date()

    const oneDay = [1, 2, 3, 4, 
                    5, 6, 7, 8, 
                    9, 10, 11, 12, 
                    13, 14, 15, 16, 
                    17, 18, 19, 20, 
                    21, 22, 23, 24, 
                    25, 26, 27, 28, 
                    29, 30, 31]

    let getDay = date.getDay()

    let lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0).getDate();

    // for (let d = 1; d <= lastDay; d++) {
    //     days += `<div>${d}</div>`;
    //     btnCalendar.innerHTML = days
    // }

    console.log(getDay);
  }

  useEffect(() => {
    // data()
  });


  return (

    <div className='pageTaskCalendar'>
      <Header />
      <Navbar />
      <VLibras />
      <h2 className="pageTitle h2">Painel Organizacional</h2>
      <div className='taskCalendar'>
        <section className="task">
          <div className="toDo">
            <h5 className="taskTitle h5">A Fazer</h5>
            <div className="taskSpace" draggable="true">
              <p className="cardTask p">Lorem Ipsum is simply dummy text.</p>
            </div>
          </div>
          <div className="do">
            <h5 className="taskTitle h5">Fazendo</h5>  
            <div className="taskSpace" draggable="true">
              <p className="cardTask p">Lorem Ipsum is simply dummy text of the printing.</p>
            </div>
          </div>
          <div className="done">
            <h5 className="taskTitle h5">Feito</h5>
            <div className="taskSpace" draggable="true">
              <p className="cardTask p">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</p>
            </div>
          </div>
        </section>
        <div className="calendarAndBtn">
          <section className="calendar p">
          <div className="calendarTitle"><h5 className="h5">Calendário</h5></div>
            <input className="btnCalendar p calend1"
            type="button"
            value="1" />
            <input className="btnCalendar p calend2"
            type="button"
            value="2" />
            <input className="btnCalendar p calend3"
            type="button"
            value="3" />
            <input className="btnCalendar p calend4"
            type="button"
            value="4" />
            <input className="btnCalendar p calend5"
            type="button"
            value="5" />
            <input className="btnCalendar p calend6"
            type="button"
            value="6" />
            <input className="btnCalendar p calend7"
            type="button"
            value="7" />
            <input className="btnCalendar p calend8"
            type="button"
            value="8" />
            <input className="btnCalendar p calend9"
            type="button"
            value="9" />
            <input className="btnCalendar p calend10"
            type="button"
            value="10" />
            <input className="btnCalendar p"
            type="button"
            value="11" />
            <input className="btnCalendar p"
            type="button"
            value="12" />
            <input className="btnCalendar p"
            type="button"
            value="13" />
            <input className="btnCalendar p"
            type="button"
            value="14" />
            <input className="btnCalendar p"
            type="button"
            value="15" />
            <input className="btnCalendar p"
            type="button"
            value="16" />
            <input className="btnCalendar p"
            type="button"
            value="17" />
            <input className="btnCalendar p"
            type="button"
            value="18" />
            <input className="btnCalendar p"
            type="button"
            value="19" />
            <input className="btnCalendar p"
            type="button"
            value="20" />
            <input className="btnCalendar p"
            type="button"
            value="21" />
            <input className="btnCalendar p"
            type="button"
            value="22" />
            <input className="btnCalendar p"
            type="button"
            value="23" />
            <input className="btnCalendar p"
            type="button"
            value="24" />
            <input className="btnCalendar p"
            type="button"
            value="25" />
            <input className="btnCalendar p"
            type="button"
            value="26" />
            <input className="btnCalendar p"
            type="button"
            value="27" />
            <input className="btnCalendar p"
            type="button"
            value="28" />
            <input className="btnCalendar p"
            type="button"
            value="29" />
            <input className="btnCalendar p"
            type="button"
            value="30" />
            <div className="calend31"><input className="btnCalendar p"
            type="button"
            value="31" /></div>
          </section>
          <input
            className="btnNewTask button"
            type="button"
            value="Nova Tarefa" />
        </div>
      </div>
    </div>

  );
}

export default App;
