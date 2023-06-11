import {useState, useEffect} from 'react';

import './oneAnswer.scss';


const OneAnswer = ({setAnswer, setWrongAnswers, setType}) => {

    useEffect(() => setType('oneAnswer'), []);
    const [wa, setWA] = useState('');

    const onChangeWA = (e) => {
        let term = e.target.value;
        setWA(e.target.value);
        if(term.indexOf(',,')!== -1 || term.match(/,/g).length > 2) {
            setWA(term.slice(0, term.length -1));
       } else {
            if(term.match(/,/g).length === 2){
                setWrongAnswers(term);
                console.log(wa);
            }
       }
    }


    return(
        <div className="form login_form">
            <form> 
                <div className="answer input">
                    <label>
                        <p>Ответ на вопрос</p>
                        <input type="text" onChange={e => setAnswer(e.target.value)}/>
                    </label>
                </div>
                <div className="wrongAnswers input">
                    <label>
                        <p>Введите 3 неправильных ответа через запятую ","</p>
                        <input type="text" value={wa} onChange={onChangeWA}/>
                    </label>
                </div>
            </form>
        </div>
    )
}

export default OneAnswer;