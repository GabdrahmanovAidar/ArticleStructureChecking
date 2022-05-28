import React, { Fragment, useState } from 'react';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';

const PaginationComponent = ({ setOffset, totalArticles, articlesPerPage }) => {
    const [active, setActive] = useState(1);
    const pageNumClick = (pageNum) => {
        setActive(pageNum)
        setOffset((pageNum - 1) * articlesPerPage);
    };
    const getItems = (numOfItems) => {
        const items = [];
        const pages = Math.ceil(numOfItems / articlesPerPage) || 1;
        for (let i = active; i < ((active + 6) > pages ? (pages + 1) : active + 6); i++) {
            items.push(
                <PaginationItem key={i} active={i === active}>
                    <PaginationLink onClick={() => pageNumClick(i)}>
                        {i}
                    </PaginationLink>
                </PaginationItem>
            )
        }

        return items;
    };

    return (
        <Fragment>
            <Pagination aria-label="Page navigation example" className="pagination-primary">
                <PaginationItem>
                    <PaginationLink first onClick={() => pageNumClick(1)} />
                </PaginationItem>
                <PaginationItem >
                    <PaginationLink previous onClick={() => pageNumClick(active - 1 > 0 ? active - 1 : 1)} />
                </PaginationItem>
                {getItems(totalArticles)}
                <PaginationItem>
                    <PaginationLink next onClick={() => pageNumClick(active + 1 < Math.ceil(totalArticles / articlesPerPage) ? active + 1 : Math.ceil(totalArticles / articlesPerPage))} />
                </PaginationItem>
                <PaginationItem>
                    <PaginationLink last onClick={() => pageNumClick(Math.ceil(totalArticles / articlesPerPage))} />
                </PaginationItem>
            </Pagination>

        </Fragment>
    );
};

export default PaginationComponent;