import React, {  } from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import App from "./components/app";
import Login from './components/pages/login';
import { ApolloClient, InMemoryCache, ApolloProvider } from '@apollo/client';
import { Provider } from 'react-redux';
import configureStore from './store';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ProtectedRoute from './components/helpers/protectedRout';
import Artilces from './components/menu-pages/articles';
import ArticleCreate from './components/menu-pages/articles/articleCreate';
import ArtilceReviews from './components/menu-pages/articleReviews';
import ArticleReviewCheck from './components/menu-pages/articleReviews/check';

let store = configureStore();
const client = new ApolloClient({
    uri: 'https://hasura.zam.me/v1/graphql',
    cache: new InMemoryCache(),
    headers: {
        "Authorization": `Bearer ${localStorage.getItem("token")}`
    }
});

const Root = () => {

    // @ts-ignore
    // @ts-ignore
    return (
        <div className="App">
            <ToastContainer position="top-right" limit={3} autoClose={3000} hideProgressBar={false} newestOnTop={false} closeOnClick rtl={false} pauseOnFocusLoss draggable pauseOnHover />
            <BrowserRouter basename={`/`}>
                <Switch>
                    <Route path={`/login`}><Login /></Route>
                    {localStorage.getItem("token") ?
                        <div>
                            <App>
                                <Route exact path={`/`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <Artilces />
                                    </ProtectedRoute>
                                </Route>
                                <Route exact path={`/articles`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <Artilces />
                                    </ProtectedRoute>
                                </Route>
                                <Route exact path={`/article/create`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <ArticleCreate />
                                    </ProtectedRoute>
                                </Route>
                                <Route exact path={`/articleReviews/:id`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <ArtilceReviews />
                                    </ProtectedRoute>
                                </Route>
                                <Route exact path={`/articleReview/check`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <ArticleReviewCheck />
                                    </ProtectedRoute>
                                </Route>
                                <Route exact path={`/articleReview/check/:id`}>
                                    <ProtectedRoute allowedRoles={[]}>
                                        <ArticleReviewCheck />
                                    </ProtectedRoute>
                                </Route>
                            </App>
                        </div>
                        :
                        <Redirect to={`/login`} />
                    }
                </Switch>
            </BrowserRouter>
        </div>
    );
}

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <ApolloProvider client={client}>
                <Root />
            </ApolloProvider>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root')
);

reportWebVitals();
