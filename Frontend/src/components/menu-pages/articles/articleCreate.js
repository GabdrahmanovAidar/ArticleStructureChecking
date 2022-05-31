import React, { Fragment, useEffect, useState } from 'react';
import Select from "react-select";
import { toast } from "react-toastify";
import { Button, Col, Row, ButtonGroup, Input} from 'reactstrap';
import { useSetState } from '../../helpers/customHooks';
import { Typeahead } from "react-bootstrap-typeahead";
import TextField from '@material-ui/core/TextField';
import { articleService } from '../../../services/articleService';
import Breadcrumb from '../../breadcrumb';


const ArticleCreate = () => {

    const [articleEntity, setArticleEntity] = useSetState({
        name: "",
        engName: ""
    });

    const createArticle = async (e) => {
        let result = await articleService.create(JSON.stringify(articleEntity))
            .catch(error => {
                toast.error(<p>{error.message}</p>);
            });
        toast.info(<p>Документ создан!</p>)
        window.location.href = `${process.env.PUBLIC_URL}/articles`;
    }

    const onCancel = () => {
        window.location.href = `${process.env.PUBLIC_URL}/articles`;
    }

    return (
        <Fragment>
            <Breadcrumb parent="Home" title="Добавить новый документ" />
            <div className="col-xl-8">
                <div className="card">
                    <div className="card-body">
                        <div className="row">
                            <div className="col-xl-6 col-md-6">
                                <div className="form-group">
                                    <label className="form-label">Название документа</label>

                                    <TextField variant="outlined" size="small" className="form-control"
                                        onChange={e => { setArticleEntity({ name: e.target.value }); }} value={articleEntity.longitude} type="text" id="name" />

                                </div>
                            </div>
                            <div className="col-xl-6 col-md-6">
                                <div className="form-group">
                                    <label className="form-label">Английское название документа</label>
                                    <TextField variant="outlined" size="small" className="form-control"
                                        onChange={e => { setArticleEntity({ latitude: e.target.value }); }} value={articleEntity.latitude} type="number" id="Latitude" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <Row>
                        <Col>
                            <div className="card-footer text-left">
                                <button className="btn btn-warn" onClick={e => onCancel()}>Отмена</button>
                            </div>
                        </Col>
                        <Col>
                            <div className="card-footer text-right">
                                <button className="btn btn-primary" onClick={event => createArticle()} type="submit">Добавить</button>
                            </div>
                        </Col>
                    </Row>
                </div>
            </div>
        </Fragment>
    );
};

export default ArticleCreate;