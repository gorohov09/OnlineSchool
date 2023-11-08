import React, {useState, useEffect} from 'react';
import { Button, Container, Form } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';
import useCourseService from '../../services/CourseService';

const CreateTeacher = ({show, onHide}) => {

    const {registerUser, error, clearError} = useCourseService();
    const [itsOk, setItsOk] = useState(false);
    const [isRequest, setIsRequest] = useState(false);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');

    const handleRegister = async e => {
		e.preventDefault();
        setIsRequest(true);
		const data = await registerUser({
            firstName,
            lastName,
			email,
		  	password,
            isStudent: false
		});

		if (data?.status === 500){
			console.log('Очистка формы')
			e.target.reset(); 
            setIsRequest(false);
		}
		else{
            setItsOk(true);
            setIsRequest(false);
		}
		
	}

    useEffect(() => {
        clearError();
        setIsRequest(false);
    }, [firstName, lastName, password, email]);

    let errorMessage = (
        <div>
            <span style={{'color': '#6439ff', 'font-size': '1em'}}>
                Произошла ошибка
            </span>
        </div>
    )
    errorMessage = error ? errorMessage : null;

    let requestOkMessage = (
        <div>
            <span style={{'color': '#6439ff', 'font-size': '1em'}}>
                Преподаватель добавлен
            </span>
        </div>
    )

    requestOkMessage = itsOk ? requestOkMessage : null;

    return (
        <Container>
            <Modal
                show={show}
                onHide={onHide}
                size="lg"
                centered
            >
                <Modal.Header closeButton
                    style={{background: '#ccc2f8' }}>
                    <Modal.Title id="contained-modal-title-vcenter" style={{color: '#6439ff'}}>
                    Добавить преподавателя
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body 
                    className='d-flex flex-column align-items-center'
                    style={{background: '#ccc2f8' }}>
                    <Form.Control
                        className='mt-3 w-75'
                        placeholder='Имя'
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                    />
                    <Form.Control
                        className='mt-3 w-75'
                        placeholder='Фамилия'
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                    />
                    <Form.Control
                        className='mt-3 w-75'
                        placeholder='Почта'
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                    <Form.Control
                        className='mt-3 w-75'
                        placeholder='Пароль'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    {errorMessage}
                    {requestOkMessage}
                </Modal.Body>
                <Modal.Footer
                    style={{background: '#ccc2f8' }}>                    
                    <Button 
                    variant={'outline-light'} 
                    onClick={(e) => handleRegister(e)}
                    disabled={isRequest}
                    style={{color:'#6439ff', borderColor:'#6439ff'}}
                    >
                        Добавить
                    </Button>
                </Modal.Footer>
            </Modal>
        </Container>
    );
};

export default CreateTeacher;