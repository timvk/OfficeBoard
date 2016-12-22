var requester = (function () {
    function getItem(url) {
        var headers = getHeaders.call(this, false);
        return makeRequest('GET', url, headers, null);
    }

    function postItem(url, data) {
        var headers = getHeaders.call(this, data);
        return makeRequest('POST', url, headers, data);
    }

    function putItem(url, data) {
        var headers = getHeaders.call(this, data);
        return makeRequest('PUT', url, headers, data);
    }

    function deleteItem(url) {
        var headers = getHeaders.call(this, false);
        return makeRequest('DELETE', url, headers, null);
    }

    function makeRequest(method, url, headers, data) {
        var defer = jQuery.Deferred();

        $.ajax({
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data)
        }).
        then(function (data) {
            defer.resolve(data);
        },
        function (error) {
            defer.reject(error);
        })
        ;

        return defer.promise();
    }

    function getHeaders(isJSON) {
        var headers = {};

        if (isJSON) {
            headers['Content-Type'] = 'application/json';
        }

        return headers;
    }

    return {
        get: getItem,
        post: postItem,
        put: putItem,
        delete: deleteItem
    }
}());