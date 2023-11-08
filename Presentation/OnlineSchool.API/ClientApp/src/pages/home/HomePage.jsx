import React from "react";

import Sidebar from "../../components/sidebar/Sidebar";
import Navbar from "../../components/navbar/Navbar";
import WidgetInfo from '../../components/widgetInfo/WidgetInfo';

import "./homePage.scss";

const HomePage = ({setIsAuth}) => {
    return (
        <>
        <Navbar setIsAuth={setIsAuth}/>
        <div className="home">
            <div className="left_side">
                <Sidebar />
            </div>
            <div className="right_side">
                <div className="homeContainer">
                    <div className="widgets">
                        <WidgetInfo type="students"/>
                        <WidgetInfo type="courses"/>
                    </div>
                </div>
            </div>
            
        </div>
        </>
    )
}

export default HomePage;