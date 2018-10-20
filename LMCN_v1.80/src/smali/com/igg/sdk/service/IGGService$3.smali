.class Lcom/igg/sdk/service/IGGService$3;
.super Lcom/igg/util/AsyncTask;
.source "IGGService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/igg/util/AsyncTask",
        "<",
        "Ljava/lang/Object;",
        "Ljava/lang/Integer;",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGService;

.field final synthetic val$URL:Ljava/lang/String;

.field final synthetic val$connectTimeOut:I

.field final synthetic val$delegate:Lcom/igg/sdk/service/IGGService$HeaderDelegate;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

.field final synthetic val$parameters:Ljava/util/HashMap;

.field final synthetic val$readTimeOut:I


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGService;

    .prologue
    .line 195
    iput-object p1, p0, Lcom/igg/sdk/service/IGGService$3;->this$0:Lcom/igg/sdk/service/IGGService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGService$3;->val$URL:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/service/IGGService$3;->val$parameters:Ljava/util/HashMap;

    iput p4, p0, Lcom/igg/sdk/service/IGGService$3;->val$connectTimeOut:I

    iput p5, p0, Lcom/igg/sdk/service/IGGService$3;->val$readTimeOut:I

    iput-object p6, p0, Lcom/igg/sdk/service/IGGService$3;->val$delegate:Lcom/igg/sdk/service/IGGService$HeaderDelegate;

    iput-object p7, p0, Lcom/igg/sdk/service/IGGService$3;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-direct {p0}, Lcom/igg/util/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 14
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 199
    const/4 v3, 0x0

    .line 200
    .local v3, "httpURLConnection":Ljava/net/HttpURLConnection;
    new-instance v6, Ljava/util/HashMap;

    invoke-direct {v6}, Ljava/util/HashMap;-><init>()V

    .line 202
    .local v6, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    const-string v8, ""

    .line 203
    .local v8, "str":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$3;->val$URL:Ljava/lang/String;

    .line 204
    .local v4, "httpUrl":Ljava/lang/String;
    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$parameters:Ljava/util/HashMap;

    if-eqz v10, :cond_0

    .line 205
    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$parameters:Ljava/util/HashMap;

    invoke-virtual {v10}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v10

    invoke-interface {v10}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v11

    :goto_0
    invoke-interface {v11}, Ljava/util/Iterator;->hasNext()Z

    move-result v10

    if-eqz v10, :cond_0

    invoke-interface {v11}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 206
    .local v5, "key":Ljava/lang/String;
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v12, "="

    invoke-virtual {v10, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v12

    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$parameters:Ljava/util/HashMap;

    invoke-virtual {v10, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/lang/String;

    const-string v13, "utf-8"

    invoke-static {v10, v13}, Ljava/net/URLEncoder;->encode(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v10

    invoke-virtual {v12, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v12, "&"

    invoke-virtual {v10, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    .line 207
    goto :goto_0

    .line 210
    .end local v5    # "key":Ljava/lang/String;
    :cond_0
    const-string v10, ""

    invoke-virtual {v8, v10}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v10

    if-nez v10, :cond_1

    .line 211
    const/4 v10, 0x0

    invoke-virtual {v8}, Ljava/lang/String;->length()I

    move-result v11

    add-int/lit8 v11, v11, -0x1

    invoke-virtual {v8, v10, v11}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v8

    .line 212
    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v10, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v11, "?"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    .line 215
    :cond_1
    new-instance v9, Ljava/net/URL;

    invoke-direct {v9, v4}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 216
    .local v9, "url":Ljava/net/URL;
    invoke-virtual {v9}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v10

    move-object v0, v10

    check-cast v0, Ljava/net/HttpURLConnection;

    move-object v3, v0

    .line 217
    iget v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$connectTimeOut:I

    invoke-virtual {v3, v10}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    .line 218
    iget v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$readTimeOut:I

    invoke-virtual {v3, v10}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 219
    const-string v10, "GET"

    invoke-virtual {v3, v10}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 220
    const-string v10, "Charset"

    const-string v11, "UTF-8"

    invoke-virtual {v3, v10, v11}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 222
    const-string v10, "IGGService"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "GeneralRequestListener Start requesting: "

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->getURL()Ljava/net/URL;

    move-result-object v12

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 224
    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$delegate:Lcom/igg/sdk/service/IGGService$HeaderDelegate;

    if-eqz v10, :cond_3

    .line 225
    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$3;->val$delegate:Lcom/igg/sdk/service/IGGService$HeaderDelegate;

    invoke-interface {v10}, Lcom/igg/sdk/service/IGGService$HeaderDelegate;->getHeader()Ljava/util/HashMap;

    move-result-object v2

    .line 226
    .local v2, "headHashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    if-eqz v2, :cond_3

    invoke-virtual {v2}, Ljava/util/HashMap;->size()I

    move-result v10

    if-lez v10, :cond_3

    .line 227
    invoke-virtual {v2}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v10

    invoke-interface {v10}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v11

    :goto_1
    invoke-interface {v11}, Ljava/util/Iterator;->hasNext()Z

    move-result v10

    if-eqz v10, :cond_3

    invoke-interface {v11}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 228
    .restart local v5    # "key":Ljava/lang/String;
    const-string v12, "IGGService"

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v13, "getRequest sendHeaders:"

    invoke-virtual {v10, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    const-string v13, "=>"

    invoke-virtual {v10, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v13

    invoke-virtual {v2, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/lang/String;

    invoke-virtual {v13, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-static {v12, v10}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 229
    invoke-virtual {v2, v5}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v10

    check-cast v10, Ljava/lang/String;

    invoke-virtual {v3, v5, v10}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto :goto_1

    .line 246
    .end local v2    # "headHashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v4    # "httpUrl":Ljava/lang/String;
    .end local v5    # "key":Ljava/lang/String;
    .end local v8    # "str":Ljava/lang/String;
    .end local v9    # "url":Ljava/net/URL;
    :catch_0
    move-exception v1

    .line 247
    .local v1, "e":Ljava/net/MalformedURLException;
    :try_start_1
    invoke-virtual {v1}, Ljava/net/MalformedURLException;->printStackTrace()V

    .line 248
    const-string v10, "statuscode"

    const/4 v11, 0x0

    invoke-static {v11}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 249
    const-string v10, "rawresponse"

    const/4 v11, 0x0

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 250
    const-string v10, "iggerror"

    const/16 v11, 0x190

    invoke-static {v1, v11}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 259
    if-eqz v3, :cond_2

    .line 260
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->disconnect()V

    .line 264
    .end local v1    # "e":Ljava/net/MalformedURLException;
    :cond_2
    :goto_2
    return-object v6

    .line 234
    .restart local v4    # "httpUrl":Ljava/lang/String;
    .restart local v8    # "str":Ljava/lang/String;
    .restart local v9    # "url":Ljava/net/URL;
    :cond_3
    :try_start_2
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->connect()V

    .line 235
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v7

    .line 236
    .local v7, "responseCode":I
    const-string v10, "IGGService"

    new-instance v11, Ljava/lang/StringBuilder;

    invoke-direct {v11}, Ljava/lang/StringBuilder;-><init>()V

    const-string v12, "getRequest responseCode:"

    invoke-virtual {v11, v12}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v11

    invoke-virtual {v11}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v11

    invoke-static {v10, v11}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 237
    const/16 v10, 0xc8

    if-ne v7, v10, :cond_4

    .line 238
    const-string v10, "statuscode"

    invoke-static {v7}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 239
    const-string v10, "rawresponse"

    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v11

    invoke-static {v11}, Lcom/igg/util/FileHelper;->readStream(Ljava/io/InputStream;)Ljava/lang/String;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 240
    const-string v10, "iggerror"

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_2
    .catch Ljava/net/MalformedURLException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_1
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 259
    :goto_3
    if-eqz v3, :cond_2

    .line 260
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_2

    .line 242
    :cond_4
    :try_start_3
    const-string v10, "statuscode"

    const/4 v11, 0x0

    invoke-static {v11}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 243
    const-string v10, "rawresponse"

    const/4 v11, 0x0

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 244
    const-string v10, "iggerror"

    new-instance v11, Ljava/lang/Exception;

    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    const-string v13, "responseCode"

    invoke-virtual {v12, v13}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v12

    invoke-virtual {v12, v7}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v12

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v12

    invoke-direct {v11, v12}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v12, 0x190

    invoke-static {v11, v12}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catch Ljava/net/MalformedURLException; {:try_start_3 .. :try_end_3} :catch_0
    .catch Ljava/lang/Exception; {:try_start_3 .. :try_end_3} :catch_1
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    goto :goto_3

    .line 252
    .end local v4    # "httpUrl":Ljava/lang/String;
    .end local v7    # "responseCode":I
    .end local v8    # "str":Ljava/lang/String;
    .end local v9    # "url":Ljava/net/URL;
    :catch_1
    move-exception v1

    .line 253
    .local v1, "e":Ljava/lang/Exception;
    :try_start_4
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    .line 254
    const-string v10, "statuscode"

    const/4 v11, 0x0

    invoke-static {v11}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 255
    const-string v10, "rawresponse"

    const/4 v11, 0x0

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 256
    const-string v10, "iggerror"

    const/16 v11, 0x190

    invoke-static {v1, v11}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v11

    invoke-virtual {v6, v10, v11}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_4
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 259
    if-eqz v3, :cond_2

    .line 260
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->disconnect()V

    goto/16 :goto_2

    .line 259
    .end local v1    # "e":Ljava/lang/Exception;
    :catchall_0
    move-exception v10

    if-eqz v3, :cond_5

    .line 260
    invoke-virtual {v3}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_5
    throw v10
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 6
    .param p1, "map"    # Ljava/lang/Object;

    .prologue
    .line 271
    move-object v0, p1

    check-cast v0, Ljava/util/HashMap;

    .line 272
    .local v0, "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v4, "statuscode"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Integer;

    invoke-virtual {v4}, Ljava/lang/Integer;->intValue()I

    move-result v3

    .line 273
    .local v3, "statusCode":I
    const-string v4, "iggerror"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igg/sdk/error/IGGError;

    .line 275
    .local v1, "iggError":Lcom/igg/sdk/error/IGGError;
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    if-eqz v4, :cond_0

    .line 276
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 281
    .local v2, "rawResponse":Ljava/lang/String;
    :goto_0
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$3;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    invoke-interface {v4, v1, v5, v2}, Lcom/igg/sdk/service/IGGService$GeneralRequestListener;->onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V

    .line 282
    return-void

    .line 278
    .end local v2    # "rawResponse":Ljava/lang/String;
    :cond_0
    const/4 v2, 0x0

    .restart local v2    # "rawResponse":Ljava/lang/String;
    goto :goto_0
.end method
