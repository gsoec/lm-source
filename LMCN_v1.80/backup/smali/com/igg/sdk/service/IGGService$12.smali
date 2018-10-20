.class Lcom/igg/sdk/service/IGGService$12;
.super Lcom/igg/util/AsyncTask;
.source "IGGService.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGService;->postFileRequest(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
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

.field final synthetic val$fileParameterName:Ljava/lang/String;

.field final synthetic val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

.field final synthetic val$newFileName:Ljava/lang/String;

.field final synthetic val$parameters:Ljava/util/HashMap;

.field final synthetic val$pathToOurFile:Ljava/lang/String;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGService;

    .prologue
    .line 1033
    iput-object p1, p0, Lcom/igg/sdk/service/IGGService$12;->this$0:Lcom/igg/sdk/service/IGGService;

    iput-object p2, p0, Lcom/igg/sdk/service/IGGService$12;->val$URL:Ljava/lang/String;

    iput-object p3, p0, Lcom/igg/sdk/service/IGGService$12;->val$parameters:Ljava/util/HashMap;

    iput-object p4, p0, Lcom/igg/sdk/service/IGGService$12;->val$pathToOurFile:Ljava/lang/String;

    iput-object p5, p0, Lcom/igg/sdk/service/IGGService$12;->val$fileParameterName:Ljava/lang/String;

    iput-object p6, p0, Lcom/igg/sdk/service/IGGService$12;->val$newFileName:Ljava/lang/String;

    iput-object p7, p0, Lcom/igg/sdk/service/IGGService$12;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-direct {p0}, Lcom/igg/util/AsyncTask;-><init>()V

    return-void
.end method


# virtual methods
.method protected varargs doInBackground([Ljava/lang/Object;)Ljava/lang/Object;
    .locals 29
    .param p1, "params"    # [Ljava/lang/Object;

    .prologue
    .line 1037
    const/4 v15, 0x0

    .line 1038
    .local v15, "httpURLConnection":Ljava/net/HttpURLConnection;
    new-instance v19, Ljava/util/HashMap;

    invoke-direct/range {v19 .. v19}, Ljava/util/HashMap;-><init>()V

    .line 1041
    .local v19, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    :try_start_0
    invoke-static {}, Ljava/util/UUID;->randomUUID()Ljava/util/UUID;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/util/UUID;->toString()Ljava/lang/String;

    move-result-object v3

    .line 1042
    .local v3, "BOUNDARY":Ljava/lang/String;
    const-string v7, "--"

    .local v7, "PREFIX":Ljava/lang/String;
    const-string v5, "\r\n"

    .line 1043
    .local v5, "LINEND":Ljava/lang/String;
    const-string v6, "multipart/form-data"

    .line 1044
    .local v6, "MULTIPART_FROM_DATA":Ljava/lang/String;
    const-string v4, "UTF-8"

    .line 1046
    .local v4, "CHARSET":Ljava/lang/String;
    new-instance v24, Ljava/net/URL;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/service/IGGService$12;->val$URL:Ljava/lang/String;

    move-object/from16 v25, v0

    invoke-direct/range {v24 .. v25}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 1047
    .local v24, "url":Ljava/net/URL;
    invoke-virtual/range {v24 .. v24}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v10

    check-cast v10, Ljava/net/HttpURLConnection;

    .line 1048
    .local v10, "conn":Ljava/net/HttpURLConnection;
    const/16 v25, 0x1388

    move/from16 v0, v25

    invoke-virtual {v10, v0}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 1049
    const/16 v25, 0x1

    move/from16 v0, v25

    invoke-virtual {v10, v0}, Ljava/net/HttpURLConnection;->setDoInput(Z)V

    .line 1050
    const/16 v25, 0x1

    move/from16 v0, v25

    invoke-virtual {v10, v0}, Ljava/net/HttpURLConnection;->setDoOutput(Z)V

    .line 1051
    const/16 v25, 0x0

    move/from16 v0, v25

    invoke-virtual {v10, v0}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    .line 1052
    const-string v25, "POST"

    move-object/from16 v0, v25

    invoke-virtual {v10, v0}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 1053
    const-string v25, "connection"

    const-string v26, "keep-alive"

    move-object/from16 v0, v25

    move-object/from16 v1, v26

    invoke-virtual {v10, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 1054
    const-string v25, "Charsert"

    const-string v26, "UTF-8"

    move-object/from16 v0, v25

    move-object/from16 v1, v26

    invoke-virtual {v10, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 1055
    const-string v25, "Content-Type"

    new-instance v26, Ljava/lang/StringBuilder;

    invoke-direct/range {v26 .. v26}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v26

    invoke-virtual {v0, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    const-string v27, ";boundary="

    invoke-virtual/range {v26 .. v27}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    move-object/from16 v0, v26

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    invoke-virtual/range {v26 .. v26}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v26

    move-object/from16 v0, v25

    move-object/from16 v1, v26

    invoke-virtual {v10, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 1058
    new-instance v22, Ljava/lang/StringBuilder;

    invoke-direct/range {v22 .. v22}, Ljava/lang/StringBuilder;-><init>()V

    .line 1059
    .local v22, "sb":Ljava/lang/StringBuilder;
    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/service/IGGService$12;->val$parameters:Ljava/util/HashMap;

    move-object/from16 v25, v0

    invoke-virtual/range {v25 .. v25}, Ljava/util/HashMap;->entrySet()Ljava/util/Set;

    move-result-object v25

    invoke-interface/range {v25 .. v25}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v26

    :goto_0
    invoke-interface/range {v26 .. v26}, Ljava/util/Iterator;->hasNext()Z

    move-result v25

    if-eqz v25, :cond_1

    invoke-interface/range {v26 .. v26}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v13

    check-cast v13, Ljava/util/Map$Entry;

    .line 1060
    .local v13, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    move-object/from16 v0, v22

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1061
    move-object/from16 v0, v22

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1062
    move-object/from16 v0, v22

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1063
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v27, "Content-Disposition: form-data; name=\""

    move-object/from16 v0, v25

    move-object/from16 v1, v27

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v27

    invoke-interface {v13}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v25

    check-cast v25, Ljava/lang/String;

    move-object/from16 v0, v27

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    const-string v27, "\""

    move-object/from16 v0, v25

    move-object/from16 v1, v27

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v22

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1064
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v27, "Content-Type: text/plain; charset="

    move-object/from16 v0, v25

    move-object/from16 v1, v27

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v22

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1065
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v27, "Content-Transfer-Encoding: 8bit"

    move-object/from16 v0, v25

    move-object/from16 v1, v27

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v22

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1066
    move-object/from16 v0, v22

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1067
    invoke-interface {v13}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v25

    check-cast v25, Ljava/lang/String;

    move-object/from16 v0, v22

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1068
    move-object/from16 v0, v22

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    goto/16 :goto_0

    .line 1117
    .end local v3    # "BOUNDARY":Ljava/lang/String;
    .end local v4    # "CHARSET":Ljava/lang/String;
    .end local v5    # "LINEND":Ljava/lang/String;
    .end local v6    # "MULTIPART_FROM_DATA":Ljava/lang/String;
    .end local v7    # "PREFIX":Ljava/lang/String;
    .end local v10    # "conn":Ljava/net/HttpURLConnection;
    .end local v13    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v22    # "sb":Ljava/lang/StringBuilder;
    .end local v24    # "url":Ljava/net/URL;
    :catch_0
    move-exception v11

    .line 1118
    .local v11, "e":Ljava/net/MalformedURLException;
    :try_start_1
    invoke-virtual {v11}, Ljava/net/MalformedURLException;->printStackTrace()V

    .line 1119
    const-string v25, "statuscode"

    const/16 v26, 0x0

    invoke-static/range {v26 .. v26}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1120
    const-string v25, "rawresponse"

    const/16 v26, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1121
    const-string v25, "iggerror"

    const/16 v26, 0x190

    move/from16 v0, v26

    invoke-static {v11, v0}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    .line 1130
    if-eqz v15, :cond_0

    .line 1131
    invoke-virtual {v15}, Ljava/net/HttpURLConnection;->disconnect()V

    .line 1135
    .end local v11    # "e":Ljava/net/MalformedURLException;
    :cond_0
    :goto_1
    return-object v19

    .line 1071
    .restart local v3    # "BOUNDARY":Ljava/lang/String;
    .restart local v4    # "CHARSET":Ljava/lang/String;
    .restart local v5    # "LINEND":Ljava/lang/String;
    .restart local v6    # "MULTIPART_FROM_DATA":Ljava/lang/String;
    .restart local v7    # "PREFIX":Ljava/lang/String;
    .restart local v10    # "conn":Ljava/net/HttpURLConnection;
    .restart local v22    # "sb":Ljava/lang/StringBuilder;
    .restart local v24    # "url":Ljava/net/URL;
    :cond_1
    :try_start_2
    new-instance v20, Ljava/io/DataOutputStream;

    invoke-virtual {v10}, Ljava/net/HttpURLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v25

    move-object/from16 v0, v20

    move-object/from16 v1, v25

    invoke-direct {v0, v1}, Ljava/io/DataOutputStream;-><init>(Ljava/io/OutputStream;)V

    .line 1072
    .local v20, "outStream":Ljava/io/DataOutputStream;
    invoke-virtual/range {v22 .. v22}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/String;->getBytes()[B

    move-result-object v25

    move-object/from16 v0, v20

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/io/DataOutputStream;->write([B)V

    .line 1073
    const/16 v16, 0x0

    .line 1075
    .local v16, "in":Ljava/io/InputStream;
    new-instance v14, Ljava/io/File;

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/service/IGGService$12;->val$pathToOurFile:Ljava/lang/String;

    move-object/from16 v25, v0

    move-object/from16 v0, v25

    invoke-direct {v14, v0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 1076
    .local v14, "file":Ljava/io/File;
    if-eqz v14, :cond_3

    .line 1077
    new-instance v9, Ljava/lang/StringBuilder;

    invoke-direct {v9}, Ljava/lang/StringBuilder;-><init>()V

    .line 1078
    .local v9, "builder":Ljava/lang/StringBuilder;
    invoke-virtual {v9, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1079
    invoke-virtual {v9, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1080
    invoke-virtual {v9, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1082
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "Content-Disposition: form-data; name=\""

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/service/IGGService$12;->val$fileParameterName:Ljava/lang/String;

    move-object/from16 v26, v0

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    const-string v26, "\"; filename=\""

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, p0

    iget-object v0, v0, Lcom/igg/sdk/service/IGGService$12;->val$newFileName:Ljava/lang/String;

    move-object/from16 v26, v0

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    const-string v26, "\""

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v9, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1083
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "Content-Type: application/octet-stream; charset="

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v9, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1084
    invoke-virtual {v9, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 1085
    invoke-virtual {v9}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/String;->getBytes()[B

    move-result-object v25

    move-object/from16 v0, v20

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/io/DataOutputStream;->write([B)V

    .line 1087
    new-instance v17, Ljava/io/FileInputStream;

    move-object/from16 v0, v17

    invoke-direct {v0, v14}, Ljava/io/FileInputStream;-><init>(Ljava/io/File;)V

    .line 1088
    .local v17, "is":Ljava/io/InputStream;
    const/16 v25, 0x400

    move/from16 v0, v25

    new-array v8, v0, [B

    .line 1089
    .local v8, "buffer":[B
    const/16 v18, 0x0

    .line 1090
    .local v18, "len":I
    :goto_2
    move-object/from16 v0, v17

    invoke-virtual {v0, v8}, Ljava/io/InputStream;->read([B)I

    move-result v18

    const/16 v25, -0x1

    move/from16 v0, v18

    move/from16 v1, v25

    if-eq v0, v1, :cond_2

    .line 1091
    const/16 v25, 0x0

    move-object/from16 v0, v20

    move/from16 v1, v25

    move/from16 v2, v18

    invoke-virtual {v0, v8, v1, v2}, Ljava/io/DataOutputStream;->write([BII)V
    :try_end_2
    .catch Ljava/net/MalformedURLException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/lang/Exception; {:try_start_2 .. :try_end_2} :catch_1
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    goto :goto_2

    .line 1123
    .end local v3    # "BOUNDARY":Ljava/lang/String;
    .end local v4    # "CHARSET":Ljava/lang/String;
    .end local v5    # "LINEND":Ljava/lang/String;
    .end local v6    # "MULTIPART_FROM_DATA":Ljava/lang/String;
    .end local v7    # "PREFIX":Ljava/lang/String;
    .end local v8    # "buffer":[B
    .end local v9    # "builder":Ljava/lang/StringBuilder;
    .end local v10    # "conn":Ljava/net/HttpURLConnection;
    .end local v14    # "file":Ljava/io/File;
    .end local v16    # "in":Ljava/io/InputStream;
    .end local v17    # "is":Ljava/io/InputStream;
    .end local v18    # "len":I
    .end local v20    # "outStream":Ljava/io/DataOutputStream;
    .end local v22    # "sb":Ljava/lang/StringBuilder;
    .end local v24    # "url":Ljava/net/URL;
    :catch_1
    move-exception v11

    .line 1124
    .local v11, "e":Ljava/lang/Exception;
    :try_start_3
    invoke-virtual {v11}, Ljava/lang/Exception;->printStackTrace()V

    .line 1125
    const-string v25, "statuscode"

    const/16 v26, 0x0

    invoke-static/range {v26 .. v26}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1126
    const-string v25, "rawresponse"

    const/16 v26, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1127
    const-string v25, "iggerror"

    const/16 v26, 0x190

    move/from16 v0, v26

    invoke-static {v11, v0}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 1130
    if-eqz v15, :cond_0

    .line 1131
    invoke-virtual {v15}, Ljava/net/HttpURLConnection;->disconnect()V

    goto/16 :goto_1

    .line 1094
    .end local v11    # "e":Ljava/lang/Exception;
    .restart local v3    # "BOUNDARY":Ljava/lang/String;
    .restart local v4    # "CHARSET":Ljava/lang/String;
    .restart local v5    # "LINEND":Ljava/lang/String;
    .restart local v6    # "MULTIPART_FROM_DATA":Ljava/lang/String;
    .restart local v7    # "PREFIX":Ljava/lang/String;
    .restart local v8    # "buffer":[B
    .restart local v9    # "builder":Ljava/lang/StringBuilder;
    .restart local v10    # "conn":Ljava/net/HttpURLConnection;
    .restart local v14    # "file":Ljava/io/File;
    .restart local v16    # "in":Ljava/io/InputStream;
    .restart local v17    # "is":Ljava/io/InputStream;
    .restart local v18    # "len":I
    .restart local v20    # "outStream":Ljava/io/DataOutputStream;
    .restart local v22    # "sb":Ljava/lang/StringBuilder;
    .restart local v24    # "url":Ljava/net/URL;
    :cond_2
    :try_start_4
    invoke-virtual/range {v17 .. v17}, Ljava/io/InputStream;->close()V

    .line 1095
    invoke-virtual {v5}, Ljava/lang/String;->getBytes()[B

    move-result-object v25

    move-object/from16 v0, v20

    move-object/from16 v1, v25

    invoke-virtual {v0, v1}, Ljava/io/DataOutputStream;->write([B)V

    .line 1097
    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v25

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v7}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/String;->getBytes()[B

    move-result-object v12

    .line 1098
    .local v12, "end_data":[B
    move-object/from16 v0, v20

    invoke-virtual {v0, v12}, Ljava/io/DataOutputStream;->write([B)V

    .line 1099
    invoke-virtual/range {v20 .. v20}, Ljava/io/DataOutputStream;->flush()V

    .line 1100
    invoke-virtual {v10}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v23

    .line 1101
    .local v23, "statusCode":I
    const/16 v25, 0xc8

    move/from16 v0, v23

    move/from16 v1, v25

    if-ne v0, v1, :cond_4

    .line 1103
    invoke-virtual {v10}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v25

    invoke-static/range {v25 .. v25}, Lcom/igg/util/FileHelper;->readStream(Ljava/io/InputStream;)Ljava/lang/String;

    move-result-object v21

    .line 1104
    .local v21, "rawResponse":Ljava/lang/String;
    const-string v25, "IGGService"

    new-instance v26, Ljava/lang/StringBuilder;

    invoke-direct/range {v26 .. v26}, Ljava/lang/StringBuilder;-><init>()V

    const-string v27, "rawResponse: "

    invoke-virtual/range {v26 .. v27}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    move-object/from16 v0, v26

    move-object/from16 v1, v21

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    invoke-virtual/range {v26 .. v26}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v26

    invoke-static/range {v25 .. v26}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 1105
    const-string v25, "statuscode"

    invoke-static/range {v23 .. v23}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1106
    const-string v25, "rawresponse"

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v21

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1107
    const-string v25, "iggerror"

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1113
    .end local v21    # "rawResponse":Ljava/lang/String;
    :goto_3
    invoke-virtual/range {v20 .. v20}, Ljava/io/DataOutputStream;->close()V

    .line 1114
    invoke-virtual {v10}, Ljava/net/HttpURLConnection;->disconnect()V
    :try_end_4
    .catch Ljava/net/MalformedURLException; {:try_start_4 .. :try_end_4} :catch_0
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_1
    .catchall {:try_start_4 .. :try_end_4} :catchall_0

    .line 1130
    .end local v8    # "buffer":[B
    .end local v9    # "builder":Ljava/lang/StringBuilder;
    .end local v12    # "end_data":[B
    .end local v17    # "is":Ljava/io/InputStream;
    .end local v18    # "len":I
    .end local v23    # "statusCode":I
    :cond_3
    if-eqz v15, :cond_0

    .line 1131
    invoke-virtual {v15}, Ljava/net/HttpURLConnection;->disconnect()V

    goto/16 :goto_1

    .line 1109
    .restart local v8    # "buffer":[B
    .restart local v9    # "builder":Ljava/lang/StringBuilder;
    .restart local v12    # "end_data":[B
    .restart local v17    # "is":Ljava/io/InputStream;
    .restart local v18    # "len":I
    .restart local v23    # "statusCode":I
    :cond_4
    :try_start_5
    const-string v25, "statuscode"

    const/16 v26, 0x0

    invoke-static/range {v26 .. v26}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1110
    const-string v25, "rawresponse"

    const/16 v26, 0x0

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 1111
    const-string v25, "iggerror"

    new-instance v26, Ljava/lang/Exception;

    new-instance v27, Ljava/lang/StringBuilder;

    invoke-direct/range {v27 .. v27}, Ljava/lang/StringBuilder;-><init>()V

    const-string v28, "statusCode:"

    invoke-virtual/range {v27 .. v28}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v27

    move-object/from16 v0, v27

    move/from16 v1, v23

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v27

    invoke-virtual/range {v27 .. v27}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v27

    invoke-direct/range {v26 .. v27}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    const/16 v27, 0x190

    invoke-static/range {v26 .. v27}, Lcom/igg/sdk/error/IGGError;->systemError(Ljava/lang/Exception;I)Lcom/igg/sdk/error/IGGError;

    move-result-object v26

    move-object/from16 v0, v19

    move-object/from16 v1, v25

    move-object/from16 v2, v26

    invoke-virtual {v0, v1, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;
    :try_end_5
    .catch Ljava/net/MalformedURLException; {:try_start_5 .. :try_end_5} :catch_0
    .catch Ljava/lang/Exception; {:try_start_5 .. :try_end_5} :catch_1
    .catchall {:try_start_5 .. :try_end_5} :catchall_0

    goto :goto_3

    .line 1130
    .end local v3    # "BOUNDARY":Ljava/lang/String;
    .end local v4    # "CHARSET":Ljava/lang/String;
    .end local v5    # "LINEND":Ljava/lang/String;
    .end local v6    # "MULTIPART_FROM_DATA":Ljava/lang/String;
    .end local v7    # "PREFIX":Ljava/lang/String;
    .end local v8    # "buffer":[B
    .end local v9    # "builder":Ljava/lang/StringBuilder;
    .end local v10    # "conn":Ljava/net/HttpURLConnection;
    .end local v12    # "end_data":[B
    .end local v14    # "file":Ljava/io/File;
    .end local v16    # "in":Ljava/io/InputStream;
    .end local v17    # "is":Ljava/io/InputStream;
    .end local v18    # "len":I
    .end local v20    # "outStream":Ljava/io/DataOutputStream;
    .end local v22    # "sb":Ljava/lang/StringBuilder;
    .end local v23    # "statusCode":I
    .end local v24    # "url":Ljava/net/URL;
    :catchall_0
    move-exception v25

    if-eqz v15, :cond_5

    .line 1131
    invoke-virtual {v15}, Ljava/net/HttpURLConnection;->disconnect()V

    :cond_5
    throw v25
.end method

.method protected onPostExecute(Ljava/lang/Object;)V
    .locals 6
    .param p1, "map"    # Ljava/lang/Object;

    .prologue
    .line 1142
    move-object v0, p1

    check-cast v0, Ljava/util/HashMap;

    .line 1143
    .local v0, "hashMap":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;"
    const-string v4, "statuscode"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/lang/Integer;

    invoke-virtual {v4}, Ljava/lang/Integer;->intValue()I

    move-result v3

    .line 1144
    .local v3, "statusCode":I
    const-string v4, "iggerror"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/igg/sdk/error/IGGError;

    .line 1146
    .local v1, "iggError":Lcom/igg/sdk/error/IGGError;
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    if-eqz v4, :cond_0

    .line 1147
    const-string v4, "rawresponse"

    invoke-virtual {v0, v4}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Ljava/lang/String;

    .line 1152
    .local v2, "rawResponse":Ljava/lang/String;
    :goto_0
    iget-object v4, p0, Lcom/igg/sdk/service/IGGService$12;->val$listener:Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    invoke-interface {v4, v1, v5, v2}, Lcom/igg/sdk/service/IGGService$GeneralRequestListener;->onGeneralRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/lang/Integer;Ljava/lang/String;)V

    .line 1153
    return-void

    .line 1149
    .end local v2    # "rawResponse":Ljava/lang/String;
    :cond_0
    const/4 v2, 0x0

    .restart local v2    # "rawResponse":Ljava/lang/String;
    goto :goto_0
.end method
