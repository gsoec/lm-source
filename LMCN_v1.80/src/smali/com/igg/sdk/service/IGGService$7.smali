.class Lcom/igg/sdk/service/IGGService$7;
.super Lcom/igg/util/AsyncTask;
.source "IGGService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGService;->postJSONRequest(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
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

.field final synthetic val$connectionTimeOut:I

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

.field final synthetic val$parameter:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;ILjava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGService;

    .prologue
    .line 680
    iput-object p1, p0, Lcom/igg/sdk/service/IGGService$7;->this$0:Lcom/igg/sdk/service/IGGService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGService$7;->val$URL:Ljava/lang/String;

    iput p3, p0, Lcom/igg/sdk/service/IGGService$7;->val$connectionTimeOut:I

    iput-object p4, p0, Lcom/igg/sdk/service/IGGService$7;->val$parameter:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/sdk/service/IGGService$7;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-direct {p0}, Lcom/igg/util/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method final convertStreamToString(Ljava/io/InputStream;)Ljava/lang/String;
    .locals 5
    .param p1, "is"    # Ljava/io/InputStream;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 682
    new-instance v2, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v2}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 683
    .local v2, "os":Ljava/io/ByteArrayOutputStream;
    const/16 v4, 0x400

    new-array v0, v4, [B

    .line 684
    .local v0, "buffer":[B
    const/4 v1, -0x1

    .line 685
    .local v1, "len":I
    :goto_0
    invoke-virtual {p1, v0}, Ljava/io/InputStream;->read([B)I

    move-result v1

    const/4 v4, -0x1

    if-eq v1, v4, :cond_0

    .line 686
    const/4 v4, 0x0

    invoke-virtual {v2, v0, v4, v1}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :goto_0

    .line 689
    :cond_0
    invoke-virtual {p1}, Ljava/io/InputStream;->close()V

    .line 690
    invoke-virtual {v2}, Ljava/io/ByteArrayOutputStream;->toString()Ljava/lang/String;

    move-result-object v3

    .line 691
    .local v3, "result":Ljava/lang/String;
    invoke-virtual {v2}, Ljava/io/ByteArrayOutputStream;->close()V

    .line 692
    return-object v3
.end method

.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 12
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 697
    const/4 v2, 0x0

    .line 698
    .local v2, "httpURLConnection":Ljava/net/HttpURLConnection;
    new-instance v3, Ljava/util/HashMap;

    invoke-direct {v3}, Ljava/util/HashMap;-><init>()V

    .line 700
    .local v3, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    new-instance v7, Ljava/net/URL;

    iget-object v8, p0, Lcom/igg/sdk/service/IGGService$7;->val$URL:Ljava/lang/String;

    invoke-direct {v7, v8}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 701
    .local v7, "url":Ljava/net/URL;
    invoke-virtual {v7}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v8

    move-object v0, v8

    check-cast v0, Ljava/net/HttpURLConnection;

    move-object v2, v0

    .line 702
    iget v8, p0, Lcom/igg/sdk/service/IGGService$7;->val$connectionTimeOut:I

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    .line 703
    const/16 v8, 0x3a98

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 704
    const-string v8, "POST"

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 705
    const-string v8, "Content-Type"

    const-string v9, "application/json"

    invoke-virtual {v2, v8, v9}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 706
    const/4 v8, 0x1

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setDoOutput(Z)V

    .line 707
    const/4 v8, 0x1

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setDoInput(Z)V

    .line 708
    const/4 v8, 0x0

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    .line 709
    const/4 v8, 0x1

    invoke-virtual {v2, v8}, Ljava/net/HttpURLConnection;->setInstanceFollowRedirects(Z)V

    .line 710
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->connect()V

    .line 711
    const-string v8, "IGGService"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "postJSONRequest doInBackground params:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    iget-object v10, p0, Lcom/igg/sdk/service/IGGService$7;->val$parameter:Ljava/lang/String;

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 712
    new-instance v4, Ljava/io/DataOutputStream;

    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v8

    invoke-direct {v4, v8}, Ljava/io/DataOutputStream;-><init>(Ljava/io/OutputStream;)V

    .line 713
    .local v4, "out":Ljava/io/DataOutputStream;
    iget-object v8, p0, Lcom/igg/sdk/service/IGGService$7;->val$parameter:Ljava/lang/String;

    invoke-virtual {v4, v8}, Ljava/io/DataOutputStream;->writeBytes(Ljava/lang/String;)V

    .line 714
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->flush()V

    .line 715
    invoke-virtual {v4}, Ljava/io/DataOutputStream;->close()V

    .line 716
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v5

    .line 717
    .local v5, "responseCode":I
    const-string v8, "IGGService"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "postJSONRequest responseCode:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 718
    const/16 v8, 0xc8

    if-ne v5, v8, :cond_1

    .line 719
    const-string v8, "statuscode"

    invoke-static {v5}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 720
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v8

    invoke-virtual {p0, v8}, Lcom/igg/sdk/service/IGGService$7;->convertStreamToString(Ljava/io/InputStream;)Ljava/lang/String;

    move-result-object v6

    .line 721
    .local v6, "result":Ljava/lang/String;
    const-string v8, "IGGService"

    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    const-string v10, "postJSONRequest result:"

    invoke-virtual {v9, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v9

    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 722
    const-string v8, "rawresponse"

    invoke-virtual {v3, v8, v6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 723
    const-string v8, "iggerror"

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 742
    .end local v6    # "result":Ljava/lang/String;
    :goto_0
    if-eqz v2, :cond_0

    .line 743
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->disconnect()V

    .line 747
    .end local v4    # "out":Ljava/io/DataOutputStream;
    .end local v5    # "responseCode":I
    .end local v7    # "url":Ljava/net/URL;
    :cond_0
    :goto_1
    return-object v3

    .line 725
    .restart local v4    # "out":Ljava/io/DataOutputStream;
    .restart local v5    # "responseCode":I
    .restart local v7    # "url":Ljava/net/URL;
    :cond_1
    :try_start_1
    const-string v8, "statuscode"

    const/4 v9, 0x0

    invoke-static {v9}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 726
    const-string v8, "rawresponse"

    const/4 v9, 0x0

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 727
    const-string v8, "iggerror"

    new-instance v9, Ljava/lang/Exception;

    new-instance v10, Ljava/lang/StringBuilder;

    invoke-direct {v10}, Ljava/lang/StringBuilder;-><init>()V

    const-string v11, "responseCode"

    invoke-virtual {v10, v11}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10, v5}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v10

    invoke-virtual {v10}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    invoke-direct {v9, v10}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v10, 0x190

    invoke-static {v9, v10}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catch Ljava/net/MalformedURLException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    goto :goto_0

    .line 729
    .end local v4    # "out":Ljava/io/DataOutputStream;
    .end local v5    # "responseCode":I
    .end local v7    # "url":Ljava/net/URL;
    :catch_0
    move-exception v1

    .line 730
    .local v1, "e":Ljava/net/MalformedURLException;
    :try_start_2
    invoke-virtual {v1}, Ljava/net/MalformedURLException;->printStackTrace()V

    .line 731
    const-string v8, "statuscode"

    const/4 v9, 0x0

    invoke-static {v9}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 732
    const-string v8, "rawresponse"

    const/4 v9, 0x0

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 733
    const-string v8, "iggerror"

    const/16 v9, 0x190

    invoke-static {v1, v9}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 742
    if-eqz v2, :cond_0

    .line 743
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_1

    .line 735
    .end local v1    # "e":Ljava/net/MalformedURLException;
    :catch_1
    move-exception v1

    .line 736
    .local v1, "e":Ljava/lang/Exception;
    :try_start_3
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    .line 737
    const-string v8, "statuscode"

    const/4 v9, 0x0

    invoke-static {v9}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 738
    const-string v8, "rawresponse"

    const/4 v9, 0x0

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 739
    const-string v8, "iggerror"

    const/16 v9, 0x190

    invoke-static {v1, v9}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v9

    invoke-virtual {v3, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 742
    if-eqz v2, :cond_0

    .line 743
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->disconnect()V

    goto :goto_1

    .line 742
    .end local v1    # "e":Ljava/lang/Exception;
    :catchall_0
    move-exception v8

    if-eqz v2, :cond_2

    .line 743
    invoke-virtual {v2}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_2
    throw v8
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 6
    .param p1, "map"    # Ljava/lang/Object;

    .prologue
    .line 753
    move-object v0, p1

    check-cast v0, Ljava/util/HashMap;

    .line 754
    .local v0, "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v4, "statuscode"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Integer;

    invoke-virtual {v4}, Ljava/lang/Integer;->intValue()I

    move-result v3

    .line 755
    .local v3, "statusCode":I
    const-string v4, "iggerror"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igg/sdk/error/IGGError;

    .line 757
    .local v1, "iggError":Lcom/igg/sdk/error/IGGError;
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    if-eqz v4, :cond_0

    .line 758
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 763
    .local v2, "rawResponse":Ljava/lang/String;
    :goto_0
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$7;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    invoke-interface {v4, v1, v5, v2}, Lcom/igg/sdk/service/IGGService$GeneralRequestListener;->onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V

    .line 764
    return-void

    .line 760
    .end local v2    # "rawResponse":Ljava/lang/String;
    :cond_0
    const/4 v2, 0x0

    .restart local v2    # "rawResponse":Ljava/lang/String;
    goto :goto_0
.end method
