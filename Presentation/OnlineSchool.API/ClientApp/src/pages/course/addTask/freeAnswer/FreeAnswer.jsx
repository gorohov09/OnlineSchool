import {useEffect} from 'react';
import './freeAnswer.scss';

const FreeAnswer = ({setAnswer, setType}) => {
    useEffect(() => setType('freeResponse'), []);
    return(
        <div className="form login_form">
            <form> 
                <div className="answer input">
                    <label>
                        <p>Ответ на вопрос</p>
                        <input type="text" onChange={e => setAnswer(e.target.value)}/>
                    </label>
                </div>
            </form>
        </div>
    )
}

export default FreeAnswer;