import React, { Fragment, useEffect, useState } from 'react';
import Select from "react-select";
import { toast } from "react-toastify";
import { Button, Col, Row, ButtonGroup, Input } from 'reactstrap';
import { useSetState } from '../../helpers/customHooks';
import { Typeahead } from "react-bootstrap-typeahead";
import TextField from '@material-ui/core/TextField';
import { articleService } from '../../../services/articleService';
import Breadcrumb from '../../breadcrumb';
import download from "../../../assets/images/other-images/download.png";
import { useParams } from 'react-router';
import { articleReviewService } from '../../../services/articleReviewService';
import { Loader } from 'react-feather';
import { getArticleStatusText } from '../../../helpers/statuses';


const ArticleReviewCheck = () => {

    const [file, setFile] = useSetState();
    const [status, setStatus] = useState();
    const [errors, setErrors] = useState([]);
    const [isLoad, setLoad] = useState(true);
    const { id } = useParams();
    const articleReviewCheckCommand = { articleReviewId: id };

    const onLoadData = async () => {
        if (id) {
            await articleReviewService.get(id).then((data) => {
                if (data) {
                    setStatus(data.status);
                    setErrors(data.errors);
                }
            });
        }
        setLoad(false);
    }
    useEffect(async () => {
        await onLoadData();
    }, [])

    const downloadDoc = async (e) => {
        if (file) {
            const formData = new FormData();
            formData.append("formFile", file.target.files[0]);
            formData.append("articleId", localStorage.getItem("articleId"));
            await articleReviewService.create(formData)
                .catch(error => {
                    toast.error(<p>{error.message}</p>);
                });
            toast.info(<p>Документ загружен на сервер!</p>)
            window.location.href = `${process.env.PUBLIC_URL}/articleReviews`;
        }
    }

    const checkDoc = async (e) => {
        await articleReviewService.check(JSON.stringify(articleReviewCheckCommand))
            .catch(error => {
                toast.error(<p>{error.message}</p>);
            });
        toast.info(<p>Проверка документа запущенна!</p>)
    }

    const onCancel = () => {
        window.location.href = `${process.env.PUBLIC_URL}/articleReviews`;
    }

    if (isLoad) {
        return <Loader />
    }

    return (
        <Fragment>
            <div className="container-fluid">
                {id ?
                    <><Breadcrumb parent="Home" title="История проверки документа" />
                        <div className="container" style={{ maxWidth: 2000 }}>
                            <div className="row justify-content-start">
                                <div className="col-4">
                                    <h3>Статус проверки документа: {getArticleStatusText(status)}</h3>
                                    {status == 0 ?
                                        <><hr /><br /><button className="btn btn-primary" onClick={event => checkDoc()} type="submit">Проверить документ</button></>
                                        :
                                        <><div className="col-8">
                                            <div className="row justify-content-start">
                                                <h3>Список ошибок и рекомендаций:</h3>
                                            </div>
                                            <br />
                                            <div className="row justify-content-start">
                                                <ul>
                                                    {errors.map((item) => <li style={{ fontSize: 20 }}>{item}</li>)}
                                                </ul>
                                            </div>
                                        </div></>
                                    }
                                </div>
                            </div>
                        </div></>
                    :
                    <><Breadcrumb parent="Home" title="Загрузка документа для проверки" />
                        <div className="container" style={{ maxWidth: 2000 }}>
                            <div className="row justify-content-start">
                                <div className="col-4">
                                    <img className="img-fluid" style={{ width: 150 }} src={download} alt="" />
                                    <Input type='file' onChange={setFile} style={{ marginTop: 60 }}></Input>
                                    <hr />
                                    <button className="btn btn-primary" onClick={event => downloadDoc()} type="submit">Загрузить документ</button>
                                </div>
                            </div>
                        </div></>
                }
            </div>
        </Fragment>
    );
};

export default ArticleReviewCheck;