import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from "react-router-dom";
import Content, { NavBar } from './routes'
import store from './redux';
import './App.css';
import logo from './logo.svg';

// store.dispatch(load());

function App() {
  return (
    <Provider store={store}>
      <Router>
        <div className="sjs-app">
          <header className="sjs-app__header">
            <div className="sjs-app__header-inner">
              <a href="https://surveyjs.io/" className="sjs-app__logo-link" target="_blank" rel="noopener noreferrer">
                <img src={logo} className="sjs-app__logo" alt="SurveyJS Logo" height="48" />
              </a>
              <NavBar/>
            </div>
          </header>
          <main className="sjs-app__content">
            <Content/>
          </main>
          <footer className="sjs-app__footer">
            <div className="sjs-app__footer-inner">
              <span>Copyright © {new Date().getFullYear()} Devsoft Baltic OÜ. All rights reserved.</span>
            </div>
          </footer>
        </div>
      </Router>
    </Provider>
  );
}

export default App;
