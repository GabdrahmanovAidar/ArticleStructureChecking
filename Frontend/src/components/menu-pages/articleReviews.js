import React, { Fragment, useEffect, useState } from 'react';
import Breadcrumb from '../breadcrumb';
import PaginationComponent from "../pagination";
import { useQuery } from "@apollo/client";
import { getDateFull, getDateOnly } from "../../helpers/date";
import countries from "i18n-iso-countries";
import { Link } from "react-router-dom";
import DataTableComponent from "../dataTableComponent";
import Loader from "../loader";
import { useHistory } from 'react-router-dom';
import axios from "axios";
import { toast } from "react-toastify";
import { articleReviewsColumn, articlesColumn } from '../../helpers/tableColumns';
import { articleService } from '../../services/articleService';
import { getArticleStatusColor, getArticleStatusText } from '../../helpers/statuses';
import { articleReviewService } from '../../services/articleReviewService';
import { useParams } from "react-router";

const ArtilceReviews = () => {
    let dataTable = [];
    const [offset, setOffset] = useState(1);
    const [datas, setData] = useState([]);
    const [isCreate, setIsCreate] = useState(false);
    const { id } = useParams();
    const onLoadData = async () => {
        if (id) {
            localStorage.removeItem("articleId");
            localStorage.setItem("articleId", id);
            await articleReviewService.getByArticleId(id).then((data) => {
                if (data) {
                    setData(data);
                }
            });
        }
    }
    useEffect(async () => {
        await onLoadData();
    }, [])

    const onCreate = () => {
        window.location.href = `${process.env.PUBLIC_URL}/articleReview/check`;
    }

    if (datas.length != 0) {
        datas.forEach(article => {
            const obj = {
                id: <Link to={"/articleReview/check/" + article.id}>{article.id}</Link>,
                status: <div className="flex"><span
                    className={`badge badge-pill badge-${getArticleStatusColor(article.status)}`}>{getArticleStatusText(article.status)}</span></div>,
                createdAt: article.createdAt
            }
            dataTable = [...dataTable, obj];
        })
    }

    return (
        <Fragment>

            <div className="container-fluid">
                <Breadcrumb parent="Home" title={"Проверки документа " + id} />
                <div className="form-group text-right">
                    <button className="btn btn-primary" onClick={event => onCreate()} type="submit">Добавить</button>
                </div>
            </div>

            <div className="container-fluid">
                <div >
                    <DataTableComponent data={dataTable} columns={articleReviewsColumn} />
                </div>
            </div>
        </Fragment>
    );
};

export default ArtilceReviews;