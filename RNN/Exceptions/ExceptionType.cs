using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Exceptions
{
    public enum ExceptionType
    {
        ARTICLE_NOT_FOUND,
        TOPIC_ALREADY_LINKED_TO_ARTICLE,
        ARTICLE_UPDATE_FAILED,
        ARTICLE_NOT_FOUND_BY_ID,
        ARTICLE_CREATION_FAILED
    }
}
