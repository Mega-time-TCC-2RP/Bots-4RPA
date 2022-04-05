import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { Link } from 'react-router-dom';
import InputMask from 'react-input-mask';

//img:
import Logo from '../../assets/img/logo2RPcadastro.png'
import RoboAzul from '../../assets/img/roboAzul.png'
import RoboVermeho from '../../assets/img/roboVermelho.png'

//Components:

//css:
import '../../assets/css/pages/registerCompany.css'
import '../../assets/css/components/button.css'
import '../../assets/css/components/fonts.css'

const steps = [
    {
        id: 'Step1'
    },
    {
        id: 'Step2'
    }
];

const onlyNumbers = (string) => string.replace(/[^0-9]/g, '')

const MaskedInputCPF = ({ value, onChange }) => {
    function handleChange(event) {
        onChange({
            ...event,
            target: {
                ...event.target, value: onlyNumbers(event.target.value)
            }
        })
    }

    return <InputMask id='placeholder-text' placeholder='Insira seu telefone...' mask="999.999.999-99" value={value} required
        onChange={handleChange}
    />
}

const MaskedInputTelephone = ({ value, onChange }) => {
    function handleChange(event) {
        onChange({
            ...event,
            target: {
                ...event.target, value: onlyNumbers(event.target.value)
            }
        })
    }

    return <InputMask id='placeholder-text' placeholder='Insira seu telefone...' mask="(99)99999-9999" value={value} required
        onChange={handleChange}
    />
}

export default function RegisterUser() {
    const [currentStep, setCurrentStep] = useState(0);
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    const [birthDate, setBirthDate] = useState();
    const [imageProfile, setImageProfile] = useState();
    const [name, setName] = useState();
    const [rg, setRg] = useState();
    const [cpf, setCpf] = useState();
    const [telephone, setTelephone] = useState();
    const [loading, setLoading] = useState(false);

    function handleNext() {
        setCurrentStep((prevState) => prevState + 1);
    }

    function handleBack() {
        setCurrentStep((prevState) => prevState - 1);
    }

    return (
        <div>
            <div className='backgroudRegister'>
                <div className='robotBlue'>
                    <img src={RoboAzul} alt="Robo Azul" />
                </div>
                <div className='registerArea'>
                    <div className='registerContent'>
                        <img className='logoRegister' src={Logo} alt="Logo 2RPnet" />
                        <form className='formRegister'>
                            {
                                steps[currentStep].id === "Step1" && (
                                    <div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Email</label>
                                            <input id='placeholder-text' type="email" name="email" placeholder='Insira o seu email...' value={email} onChange={(event) => setEmail(event.target.value)} autoFocus required />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Senha</label>
                                            <input id='placeholder-text' type="password" name="password" placeholder='Insira sua senha...' value={password} onChange={(event) => setPassword(event.target.value)} required />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Data de Nascimento</label>
                                            <input id='placeholder-text' type="date" name="birthDate" placeholder='Insira sua Data de nascimento...' value={birthDate} onChange={(event) => setBirthDate(event.target.value)} />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Imagem de Perfil</label>
                                            <input id='placeholder-text' type="file" name="imageProfile" placeholder='Insira sua foto de Perfil...' value={imageProfile} onChange={(event) => setImageProfile(event.target.value)} />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Nome</label>
                                            <input id='placeholder-text' type="text" name="name" placeholder='Insira seu Nome...' value={name} onChange={(event) => setName(event.target.value)} />
                                        </div>
                                        <button className='button' type="submit" onClick={handleNext}>Avançar</button>
                                    </div>
                                )
                            }
                            {
                                steps[currentStep].id === "Step2" && (
                                    <div className='inputsArea'>
                                        <div className='foreachInput'>
                                            <label className='h5'>RG</label>
                                            <input id='placeholder-text' type="number" name="RG" placeholder='Insira o seu RG...' value={rg} onChange={(event) => setRg(event.target.value)} autoFocus required />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>CPF</label>
                                            <MaskedInputCPF value={cpf} onChange={(event) => setCpf(event.target.value)} />
                                        </div>
                                        <div className='foreachInput'>
                                            <label className='h5'>Telefone</label>
                                            <MaskedInputTelephone value={telephone} onChange={(event) => setTelephone(event.target.value)} />
                                        </div>
                                        <button className='button' type="submit">Finalizar Cadastro</button>
                                        <button className='button' onClick={handleBack}>Voltar</button>
                                    </div>
                                )
                            }

                        </form>
                    </div>
                </div>
                <div className='robotRed'>
                    <img src={RoboVermeho} alt="Robo Vermelho" />
                </div>
            </div>
        </div>
    );
}