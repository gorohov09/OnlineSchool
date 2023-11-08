import React from "react";
import CoursesForStudentList from "../../components/coursesForStudentList/CoursesForStudentList";

import Header from "../../components/header/Header";

import "./homeStudentPage.scss";

const HomePage = ({setIsAuth}) => {
    return (
        <>
            <Header setIsAuth={setIsAuth}/>
            <div className="wrapper_home">
                <section className="all_courses">
                    <h2 className="title_courses">Популярные курсы</h2>
                    <div className="popular_courses">
                        <CoursesForStudentList />
                    </div>
                </section>
            </div>
        </>
    )
}

export default HomePage;