.class public Lcom/igg/util/UploadFileRequest;
.super Ljava/lang/Object;
.source "UploadFileRequest.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/util/UploadFileRequest$FileUploadListener;
    }
.end annotation


# static fields
.field private static final CHARSET:Ljava/lang/String; = "utf-8"

.field private static final LINE_END:Ljava/lang/String; = "\r\n"

.field private static final PREFIX:Ljava/lang/String; = "--"

.field private static final TAG:Ljava/lang/String; = "UploadFileRequest"

.field private static final TIME_OUT:I = 0x5f5e100


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static upload(Ljava/lang/String;Ljava/io/File;Ljava/util/Map;Lcom/igg/util/UploadFileRequest$FileUploadListener;)V
    .locals 28
    .param p0, "host"    # Ljava/lang/String;
    .param p1, "file"    # Ljava/io/File;
    .param p3, "listener"    # Lcom/igg/util/UploadFileRequest$FileUploadListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/io/File;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/util/UploadFileRequest$FileUploadListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 31
    .local p2, "params":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/lang/String;>;"
    invoke-static {}, Ljava/util/UUID;->randomUUID()Ljava/util/UUID;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/util/UUID;->toString()Ljava/lang/String;

    move-result-object v4

    .line 32
    .local v4, "boundary":Ljava/lang/String;
    const-string v9, "multipart/form-data"

    .line 34
    .local v9, "contentType":Ljava/lang/String;
    :try_start_0
    new-instance v21, Ljava/net/URL;

    move-object/from16 v0, v21

    move-object/from16 v1, p0

    invoke-direct {v0, v1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    .line 35
    .local v21, "url":Ljava/net/URL;
    invoke-virtual/range {v21 .. v21}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v8

    check-cast v8, Ljava/net/HttpURLConnection;

    .line 36
    .local v8, "conn":Ljava/net/HttpURLConnection;
    const v24, 0x5f5e100

    move/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setReadTimeout(I)V

    .line 37
    const v24, 0x5f5e100

    move/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setConnectTimeout(I)V

    .line 38
    const-string v24, "POST"

    move-object/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setRequestMethod(Ljava/lang/String;)V

    .line 39
    const-string v24, "Charset"

    const-string v25, "utf-8"

    move-object/from16 v0, v24

    move-object/from16 v1, v25

    invoke-virtual {v8, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 40
    const-string v24, "connection"

    const-string v25, "keep-alive"

    move-object/from16 v0, v24

    move-object/from16 v1, v25

    invoke-virtual {v8, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 41
    const-string v24, "Content-Type"

    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    move-object/from16 v0, v25

    invoke-virtual {v0, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    const-string v26, ";boundary="

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    move-object/from16 v0, v24

    move-object/from16 v1, v25

    invoke-virtual {v8, v0, v1}, Ljava/net/HttpURLConnection;->setRequestProperty(Ljava/lang/String;Ljava/lang/String;)V

    .line 42
    const/16 v24, 0x1

    move/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setDoInput(Z)V

    .line 43
    const/16 v24, 0x1

    move/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setDoOutput(Z)V

    .line 44
    const/16 v24, 0x0

    move/from16 v0, v24

    invoke-virtual {v8, v0}, Ljava/net/HttpURLConnection;->setUseCaches(Z)V

    .line 45
    if-eqz p1, :cond_0

    .line 47
    invoke-virtual {v8}, Ljava/net/HttpURLConnection;->getOutputStream()Ljava/io/OutputStream;

    move-result-object v19

    .line 48
    .local v19, "outputSteam":Ljava/io/OutputStream;
    new-instance v12, Ljava/io/DataOutputStream;

    move-object/from16 v0, v19

    invoke-direct {v12, v0}, Ljava/io/DataOutputStream;-><init>(Ljava/io/OutputStream;)V

    .line 49
    .local v12, "dos":Ljava/io/DataOutputStream;
    new-instance v20, Ljava/lang/StringBuffer;

    invoke-direct/range {v20 .. v20}, Ljava/lang/StringBuffer;-><init>()V

    .line 50
    .local v20, "sb":Ljava/lang/StringBuffer;
    const-string v24, "\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 51
    if-eqz p2, :cond_1

    .line 52
    invoke-interface/range {p2 .. p2}, Ljava/util/Map;->entrySet()Ljava/util/Set;

    move-result-object v24

    invoke-interface/range {v24 .. v24}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v25

    :goto_0
    invoke-interface/range {v25 .. v25}, Ljava/util/Iterator;->hasNext()Z

    move-result v24

    if-eqz v24, :cond_1

    invoke-interface/range {v25 .. v25}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v15

    check-cast v15, Ljava/util/Map$Entry;

    .line 53
    .local v15, "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v24, "--"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    move-result-object v24

    move-object/from16 v0, v24

    invoke-virtual {v0, v4}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    move-result-object v24

    const-string v26, "\r\n"

    move-object/from16 v0, v24

    move-object/from16 v1, v26

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 54
    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "Content-Disposition: form-data; name=\""

    move-object/from16 v0, v24

    move-object/from16 v1, v26

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v26

    invoke-interface {v15}, Ljava/util/Map$Entry;->getKey()Ljava/lang/Object;

    move-result-object v24

    check-cast v24, Ljava/lang/String;

    move-object/from16 v0, v26

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v26, "\""

    move-object/from16 v0, v24

    move-object/from16 v1, v26

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v26, "\r\n"

    move-object/from16 v0, v24

    move-object/from16 v1, v26

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 55
    const-string v24, "Content-Type: text/plain; charset=utf-8\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 56
    const-string v24, "Content-Transfer-Encoding: 8bit\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 57
    const-string v24, "\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 58
    invoke-interface {v15}, Ljava/util/Map$Entry;->getValue()Ljava/lang/Object;

    move-result-object v24

    check-cast v24, Ljava/lang/String;

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 59
    const-string v24, "\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1

    goto/16 :goto_0

    .line 108
    .end local v8    # "conn":Ljava/net/HttpURLConnection;
    .end local v12    # "dos":Ljava/io/DataOutputStream;
    .end local v15    # "entry":Ljava/util/Map$Entry;, "Ljava/util/Map$Entry<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v19    # "outputSteam":Ljava/io/OutputStream;
    .end local v20    # "sb":Ljava/lang/StringBuffer;
    .end local v21    # "url":Ljava/net/URL;
    :catch_0
    move-exception v13

    .line 109
    .local v13, "e":Ljava/net/MalformedURLException;
    invoke-virtual {v13}, Ljava/net/MalformedURLException;->printStackTrace()V

    .line 113
    .end local v13    # "e":Ljava/net/MalformedURLException;
    :cond_0
    :goto_1
    return-void

    .line 63
    .restart local v8    # "conn":Ljava/net/HttpURLConnection;
    .restart local v12    # "dos":Ljava/io/DataOutputStream;
    .restart local v19    # "outputSteam":Ljava/io/OutputStream;
    .restart local v20    # "sb":Ljava/lang/StringBuffer;
    .restart local v21    # "url":Ljava/net/URL;
    :cond_1
    :try_start_1
    const-string v24, "--"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 64
    move-object/from16 v0, v20

    invoke-virtual {v0, v4}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 65
    const-string v24, "\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 71
    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    const-string v25, "Content-Disposition: form-data; name=\"img\"; filename=\""

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {p1 .. p1}, Ljava/io/File;->getName()Ljava/lang/String;

    move-result-object v25

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, "\""

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, "\r\n"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 72
    const-string v24, "Content-Type: application/octet-stream; charset=utf-8\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 73
    const-string v24, "\r\n"

    move-object/from16 v0, v20

    move-object/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    .line 75
    invoke-virtual/range {v20 .. v20}, Ljava/lang/StringBuffer;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/String;->getBytes()[B

    move-result-object v24

    move-object/from16 v0, v24

    invoke-virtual {v12, v0}, Ljava/io/DataOutputStream;->write([B)V

    .line 76
    new-instance v16, Ljava/io/FileInputStream;

    move-object/from16 v0, v16

    move-object/from16 v1, p1

    invoke-direct {v0, v1}, Ljava/io/FileInputStream;-><init>(Ljava/io/File;)V

    .line 77
    .local v16, "is":Ljava/io/InputStream;
    const/16 v24, 0x400

    move/from16 v0, v24

    new-array v6, v0, [B

    .line 78
    .local v6, "bytes":[B
    invoke-virtual/range {p1 .. p1}, Ljava/io/File;->length()J

    move-result-wide v22

    .line 79
    .local v22, "totalbytes":J
    const-wide/16 v10, 0x0

    .line 80
    .local v10, "curbytes":J
    const-string v24, "cky"

    new-instance v25, Ljava/lang/StringBuilder;

    invoke-direct/range {v25 .. v25}, Ljava/lang/StringBuilder;-><init>()V

    const-string v26, "total="

    invoke-virtual/range {v25 .. v26}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v25

    move-object/from16 v0, v25

    move-wide/from16 v1, v22

    invoke-virtual {v0, v1, v2}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v25

    invoke-virtual/range {v25 .. v25}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v25

    invoke-static/range {v24 .. v25}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 81
    const/16 v17, 0x0

    .line 82
    .local v17, "len":I
    :goto_2
    move-object/from16 v0, v16

    invoke-virtual {v0, v6}, Ljava/io/InputStream;->read([B)I

    move-result v17

    const/16 v24, -0x1

    move/from16 v0, v17

    move/from16 v1, v24

    if-eq v0, v1, :cond_2

    .line 83
    move/from16 v0, v17

    int-to-long v0, v0

    move-wide/from16 v24, v0

    add-long v10, v10, v24

    .line 84
    const/16 v24, 0x0

    move/from16 v0, v24

    move/from16 v1, v17

    invoke-virtual {v12, v6, v0, v1}, Ljava/io/DataOutputStream;->write([BII)V

    .line 85
    const-wide/high16 v24, 0x3ff0000000000000L    # 1.0

    long-to-double v0, v10

    move-wide/from16 v26, v0

    mul-double v24, v24, v26

    move-wide/from16 v0, v22

    long-to-double v0, v0

    move-wide/from16 v26, v0

    div-double v24, v24, v26

    move-object/from16 v0, p3

    move-wide/from16 v1, v24

    invoke-interface {v0, v10, v11, v1, v2}, Lcom/igg/util/UploadFileRequest$FileUploadListener;->onProgress(JD)V
    :try_end_1
    .catch Ljava/net/MalformedURLException; {:try_start_1 .. :try_end_1} :catch_0
    .catch Ljava/io/IOException; {:try_start_1 .. :try_end_1} :catch_1

    goto :goto_2

    .line 110
    .end local v6    # "bytes":[B
    .end local v8    # "conn":Ljava/net/HttpURLConnection;
    .end local v10    # "curbytes":J
    .end local v12    # "dos":Ljava/io/DataOutputStream;
    .end local v16    # "is":Ljava/io/InputStream;
    .end local v17    # "len":I
    .end local v19    # "outputSteam":Ljava/io/OutputStream;
    .end local v20    # "sb":Ljava/lang/StringBuffer;
    .end local v21    # "url":Ljava/net/URL;
    .end local v22    # "totalbytes":J
    :catch_1
    move-exception v13

    .line 111
    .local v13, "e":Ljava/io/IOException;
    invoke-virtual {v13}, Ljava/io/IOException;->printStackTrace()V

    goto/16 :goto_1

    .line 88
    .end local v13    # "e":Ljava/io/IOException;
    .restart local v6    # "bytes":[B
    .restart local v8    # "conn":Ljava/net/HttpURLConnection;
    .restart local v10    # "curbytes":J
    .restart local v12    # "dos":Ljava/io/DataOutputStream;
    .restart local v16    # "is":Ljava/io/InputStream;
    .restart local v17    # "len":I
    .restart local v19    # "outputSteam":Ljava/io/OutputStream;
    .restart local v20    # "sb":Ljava/lang/StringBuffer;
    .restart local v21    # "url":Ljava/net/URL;
    .restart local v22    # "totalbytes":J
    :cond_2
    :try_start_2
    invoke-virtual/range {v16 .. v16}, Ljava/io/InputStream;->close()V

    .line 90
    const-string v24, "\r\n"

    invoke-virtual/range {v24 .. v24}, Ljava/lang/String;->getBytes()[B

    move-result-object v24

    move-object/from16 v0, v24

    invoke-virtual {v12, v0}, Ljava/io/DataOutputStream;->write([B)V

    .line 91
    new-instance v24, Ljava/lang/StringBuilder;

    invoke-direct/range {v24 .. v24}, Ljava/lang/StringBuilder;-><init>()V

    const-string v25, "--"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    move-object/from16 v0, v24

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, "--"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    const-string v25, "\r\n"

    invoke-virtual/range {v24 .. v25}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-virtual/range {v24 .. v24}, Ljava/lang/String;->getBytes()[B

    move-result-object v14

    .line 92
    .local v14, "end_data":[B
    invoke-virtual {v12, v14}, Ljava/io/DataOutputStream;->write([B)V

    .line 93
    invoke-virtual {v12}, Ljava/io/DataOutputStream;->flush()V

    .line 98
    invoke-virtual {v8}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v7

    .line 99
    .local v7, "code":I
    const/16 v24, 0x0

    move-object/from16 v0, v20

    move/from16 v1, v24

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->setLength(I)V

    .line 100
    new-instance v5, Ljava/io/BufferedReader;

    new-instance v24, Ljava/io/InputStreamReader;

    invoke-virtual {v8}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;

    move-result-object v25

    invoke-direct/range {v24 .. v25}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;)V

    move-object/from16 v0, v24

    invoke-direct {v5, v0}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V

    .line 102
    .local v5, "br":Ljava/io/BufferedReader;
    :goto_3
    invoke-virtual {v5}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v18

    .local v18, "line":Ljava/lang/String;
    if-eqz v18, :cond_3

    .line 103
    move-object/from16 v0, v20

    move-object/from16 v1, v18

    invoke-virtual {v0, v1}, Ljava/lang/StringBuffer;->append(Ljava/lang/String;)Ljava/lang/StringBuffer;

    goto :goto_3

    .line 106
    :cond_3
    invoke-virtual/range {v20 .. v20}, Ljava/lang/StringBuffer;->toString()Ljava/lang/String;

    move-result-object v24

    invoke-virtual {v8}, Ljava/net/HttpURLConnection;->getHeaderFields()Ljava/util/Map;

    move-result-object v25

    move-object/from16 v0, p3

    move-object/from16 v1, v24

    move-object/from16 v2, v25

    invoke-interface {v0, v7, v1, v2}, Lcom/igg/util/UploadFileRequest$FileUploadListener;->onFinish(ILjava/lang/String;Ljava/util/Map;)V
    :try_end_2
    .catch Ljava/net/MalformedURLException; {:try_start_2 .. :try_end_2} :catch_0
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_1

    goto/16 :goto_1
.end method
