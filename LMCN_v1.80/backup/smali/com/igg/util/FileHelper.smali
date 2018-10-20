.class public Lcom/igg/util/FileHelper;
.super Ljava/lang/Object;
.source "FileHelper.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 18
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static createSDDir(Ljava/lang/String;)Ljava/io/File;
    .locals 2
    .param p0, "dirName"    # Ljava/lang/String;

    .prologue
    .line 66
    new-instance v0, Ljava/io/File;

    invoke-direct {v0, p0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 67
    .local v0, "dir":Ljava/io/File;
    invoke-virtual {v0}, Ljava/io/File;->exists()Z

    move-result v1

    if-nez v1, :cond_0

    invoke-virtual {v0}, Ljava/io/File;->isDirectory()Z

    move-result v1

    if-nez v1, :cond_0

    .line 68
    invoke-virtual {v0}, Ljava/io/File;->mkdir()Z

    .line 71
    :cond_0
    return-object v0
.end method

.method public static createSDFile(Ljava/lang/String;Ljava/lang/String;)Ljava/io/File;
    .locals 2
    .param p0, "path"    # Ljava/lang/String;
    .param p1, "fileName"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/io/IOException;
        }
    .end annotation

    .prologue
    .line 83
    new-instance v0, Ljava/io/File;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 84
    .local v0, "file":Ljava/io/File;
    invoke-virtual {v0}, Ljava/io/File;->createNewFile()Z

    .line 85
    return-object v0
.end method

.method public static printLongInfo(Ljava/lang/String;)V
    .locals 5
    .param p0, "msg"    # Ljava/lang/String;

    .prologue
    const/16 v4, 0x7d0

    const/4 v3, 0x0

    .line 52
    new-instance v0, Ljava/lang/StringBuilder;

    const-string v1, ""

    invoke-direct {v0, v1}, Ljava/lang/StringBuilder;-><init>(Ljava/lang/String;)V

    .line 53
    .local v0, "str":Ljava/lang/StringBuilder;
    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 54
    :goto_0
    invoke-virtual {v0}, Ljava/lang/StringBuilder;->length()I

    move-result v1

    if-lez v1, :cond_0

    .line 55
    const-string v1, "readStream"

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->length()I

    move-result v2

    invoke-static {v4, v2}, Ljava/lang/Math;->min(II)I

    move-result v2

    invoke-virtual {v0, v3, v2}, Ljava/lang/StringBuilder;->substring(II)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/String;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 56
    invoke-virtual {v0, v3, v4}, Ljava/lang/StringBuilder;->delete(II)Ljava/lang/StringBuilder;

    goto :goto_0

    .line 58
    :cond_0
    return-void
.end method

.method public static readStream(Ljava/io/InputStream;)Ljava/lang/String;
    .locals 9
    .param p0, "in"    # Ljava/io/InputStream;

    .prologue
    .line 26
    const/4 v2, 0x0

    .line 27
    .local v2, "reader":Ljava/io/BufferedReader;
    const-string v4, ""

    .line 29
    .local v4, "result":Ljava/lang/String;
    :try_start_0
    const-string v6, "readStream"

    new-instance v7, Ljava/lang/StringBuilder;

    invoke-direct {v7}, Ljava/lang/StringBuilder;-><init>()V

    const-string v8, "readStream : "

    invoke-virtual {v7, v8}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v7

    invoke-virtual {v7}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    invoke-static {v6, v7}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 30
    new-instance v3, Ljava/io/BufferedReader;

    new-instance v6, Ljava/io/InputStreamReader;

    const-string v7, "utf-8"

    invoke-direct {v6, p0, v7}, Ljava/io/InputStreamReader;-><init>(Ljava/io/InputStream;Ljava/lang/String;)V

    invoke-direct {v3, v6}, Ljava/io/BufferedReader;-><init>(Ljava/io/Reader;)V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 31
    .end local v2    # "reader":Ljava/io/BufferedReader;
    .local v3, "reader":Ljava/io/BufferedReader;
    :try_start_1
    const-string v1, ""

    .line 32
    .local v1, "line":Ljava/lang/String;
    :goto_0
    invoke-virtual {v3}, Ljava/io/BufferedReader;->readLine()Ljava/lang/String;

    move-result-object v1

    if-eqz v1, :cond_0

    .line 33
    new-instance v6, Ljava/lang/StringBuilder;

    invoke-direct {v6}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v6, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v6

    invoke-virtual {v6}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;
    :try_end_1
    .catch Ljava/io/IOException; {:try_start_1 .. :try_end_1} :catch_4
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    move-result-object v4

    goto :goto_0

    .line 40
    :cond_0
    invoke-static {v4}, Lcom/igg/util/FileHelper;->printLongInfo(Ljava/lang/String;)V

    .line 41
    if-eqz v3, :cond_1

    .line 43
    :try_start_2
    invoke-virtual {v3}, Ljava/io/BufferedReader;->close()V
    :try_end_2
    .catch Ljava/io/IOException; {:try_start_2 .. :try_end_2} :catch_0

    :cond_1
    :goto_1
    move-object v2, v3

    .end local v3    # "reader":Ljava/io/BufferedReader;
    .restart local v2    # "reader":Ljava/io/BufferedReader;
    move-object v5, v4

    .line 38
    .end local v1    # "line":Ljava/lang/String;
    .end local v4    # "result":Ljava/lang/String;
    .local v5, "result":Ljava/lang/String;
    :goto_2
    return-object v5

    .line 44
    .end local v2    # "reader":Ljava/io/BufferedReader;
    .end local v5    # "result":Ljava/lang/String;
    .restart local v1    # "line":Ljava/lang/String;
    .restart local v3    # "reader":Ljava/io/BufferedReader;
    .restart local v4    # "result":Ljava/lang/String;
    :catch_0
    move-exception v0

    .line 45
    .local v0, "e":Ljava/io/IOException;
    invoke-virtual {v0}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_1

    .line 36
    .end local v0    # "e":Ljava/io/IOException;
    .end local v1    # "line":Ljava/lang/String;
    .end local v3    # "reader":Ljava/io/BufferedReader;
    .restart local v2    # "reader":Ljava/io/BufferedReader;
    :catch_1
    move-exception v0

    .line 37
    .restart local v0    # "e":Ljava/io/IOException;
    :goto_3
    :try_start_3
    invoke-virtual {v0}, Ljava/io/IOException;->printStackTrace()V
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    .line 40
    invoke-static {v4}, Lcom/igg/util/FileHelper;->printLongInfo(Ljava/lang/String;)V

    .line 41
    if-eqz v2, :cond_2

    .line 43
    :try_start_4
    invoke-virtual {v2}, Ljava/io/BufferedReader;->close()V
    :try_end_4
    .catch Ljava/io/IOException; {:try_start_4 .. :try_end_4} :catch_2

    :cond_2
    :goto_4
    move-object v5, v4

    .line 38
    .end local v4    # "result":Ljava/lang/String;
    .restart local v5    # "result":Ljava/lang/String;
    goto :goto_2

    .line 44
    .end local v5    # "result":Ljava/lang/String;
    .restart local v4    # "result":Ljava/lang/String;
    :catch_2
    move-exception v0

    .line 45
    invoke-virtual {v0}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_4

    .line 40
    .end local v0    # "e":Ljava/io/IOException;
    :catchall_0
    move-exception v6

    :goto_5
    invoke-static {v4}, Lcom/igg/util/FileHelper;->printLongInfo(Ljava/lang/String;)V

    .line 41
    if-eqz v2, :cond_3

    .line 43
    :try_start_5
    invoke-virtual {v2}, Ljava/io/BufferedReader;->close()V
    :try_end_5
    .catch Ljava/io/IOException; {:try_start_5 .. :try_end_5} :catch_3

    .line 46
    :cond_3
    :goto_6
    throw v6

    .line 44
    :catch_3
    move-exception v0

    .line 45
    .restart local v0    # "e":Ljava/io/IOException;
    invoke-virtual {v0}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_6

    .line 40
    .end local v0    # "e":Ljava/io/IOException;
    .end local v2    # "reader":Ljava/io/BufferedReader;
    .restart local v3    # "reader":Ljava/io/BufferedReader;
    :catchall_1
    move-exception v6

    move-object v2, v3

    .end local v3    # "reader":Ljava/io/BufferedReader;
    .restart local v2    # "reader":Ljava/io/BufferedReader;
    goto :goto_5

    .line 36
    .end local v2    # "reader":Ljava/io/BufferedReader;
    .restart local v3    # "reader":Ljava/io/BufferedReader;
    :catch_4
    move-exception v0

    move-object v2, v3

    .end local v3    # "reader":Ljava/io/BufferedReader;
    .restart local v2    # "reader":Ljava/io/BufferedReader;
    goto :goto_3
.end method

.method public static writeSDFromInput(Ljava/lang/String;Ljava/lang/String;Ljava/io/InputStream;)Ljava/io/File;
    .locals 10
    .param p0, "path"    # Ljava/lang/String;
    .param p1, "fileName"    # Ljava/lang/String;
    .param p2, "input"    # Ljava/io/InputStream;

    .prologue
    .line 97
    const/4 v2, 0x0

    .line 98
    .local v2, "file":Ljava/io/File;
    const/4 v5, 0x0

    .line 101
    .local v5, "output":Ljava/io/OutputStream;
    :try_start_0
    invoke-static {p0}, Lcom/igg/util/FileHelper;->createSDDir(Ljava/lang/String;)Ljava/io/File;

    .line 102
    invoke-static {p0, p1}, Lcom/igg/util/FileHelper;->createSDFile(Ljava/lang/String;Ljava/lang/String;)Ljava/io/File;

    move-result-object v2

    .line 103
    new-instance v6, Ljava/io/FileOutputStream;

    invoke-direct {v6, v2}, Ljava/io/FileOutputStream;-><init>(Ljava/io/File;)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_4
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    .line 104
    .end local v5    # "output":Ljava/io/OutputStream;
    .local v6, "output":Ljava/io/OutputStream;
    const/16 v7, 0x1000

    :try_start_1
    new-array v0, v7, [B

    .line 107
    .local v0, "buffer":[B
    :goto_0
    invoke-virtual {p2, v0}, Ljava/io/InputStream;->read([B)I

    move-result v4

    .local v4, "length":I
    if-lez v4, :cond_1

    .line 108
    const/4 v7, 0x0

    invoke-virtual {v6, v0, v7, v4}, Ljava/io/OutputStream;->write([BII)V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0
    .catchall {:try_start_1 .. :try_end_1} :catchall_1

    goto :goto_0

    .line 113
    .end local v0    # "buffer":[B
    .end local v4    # "length":I
    :catch_0
    move-exception v1

    move-object v5, v6

    .line 114
    .end local v6    # "output":Ljava/io/OutputStream;
    .local v1, "e":Ljava/lang/Exception;
    .restart local v5    # "output":Ljava/io/OutputStream;
    :goto_1
    :try_start_2
    const-string v7, "writeSDFromInput"

    invoke-virtual {v1}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_2
    .catchall {:try_start_2 .. :try_end_2} :catchall_0

    .line 117
    if-eqz v5, :cond_0

    .line 118
    :try_start_3
    invoke-virtual {v5}, Ljava/io/OutputStream;->close()V
    :try_end_3
    .catch Ljava/io/IOException; {:try_start_3 .. :try_end_3} :catch_2

    .line 125
    .end local v1    # "e":Ljava/lang/Exception;
    :cond_0
    :goto_2
    return-object v2

    .line 112
    .end local v5    # "output":Ljava/io/OutputStream;
    .restart local v0    # "buffer":[B
    .restart local v4    # "length":I
    .restart local v6    # "output":Ljava/io/OutputStream;
    :cond_1
    :try_start_4
    invoke-virtual {v6}, Ljava/io/OutputStream;->flush()V
    :try_end_4
    .catch Ljava/lang/Exception; {:try_start_4 .. :try_end_4} :catch_0
    .catchall {:try_start_4 .. :try_end_4} :catchall_1

    .line 117
    if-eqz v6, :cond_2

    .line 118
    :try_start_5
    invoke-virtual {v6}, Ljava/io/OutputStream;->close()V
    :try_end_5
    .catch Ljava/io/IOException; {:try_start_5 .. :try_end_5} :catch_1

    :cond_2
    move-object v5, v6

    .line 122
    .end local v6    # "output":Ljava/io/OutputStream;
    .restart local v5    # "output":Ljava/io/OutputStream;
    goto :goto_2

    .line 120
    .end local v5    # "output":Ljava/io/OutputStream;
    .restart local v6    # "output":Ljava/io/OutputStream;
    :catch_1
    move-exception v3

    .line 121
    .local v3, "ioe":Ljava/io/IOException;
    const-string v7, "writeSDFromInput"

    invoke-virtual {v3}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    move-object v5, v6

    .line 123
    .end local v6    # "output":Ljava/io/OutputStream;
    .restart local v5    # "output":Ljava/io/OutputStream;
    goto :goto_2

    .line 120
    .end local v0    # "buffer":[B
    .end local v3    # "ioe":Ljava/io/IOException;
    .end local v4    # "length":I
    .restart local v1    # "e":Ljava/lang/Exception;
    :catch_2
    move-exception v3

    .line 121
    .restart local v3    # "ioe":Ljava/io/IOException;
    const-string v7, "writeSDFromInput"

    invoke-virtual {v3}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_2

    .line 116
    .end local v1    # "e":Ljava/lang/Exception;
    .end local v3    # "ioe":Ljava/io/IOException;
    :catchall_0
    move-exception v7

    .line 117
    :goto_3
    if-eqz v5, :cond_3

    .line 118
    :try_start_6
    invoke-virtual {v5}, Ljava/io/OutputStream;->close()V
    :try_end_6
    .catch Ljava/io/IOException; {:try_start_6 .. :try_end_6} :catch_3

    .line 122
    :cond_3
    :goto_4
    throw v7

    .line 120
    :catch_3
    move-exception v3

    .line 121
    .restart local v3    # "ioe":Ljava/io/IOException;
    const-string v8, "writeSDFromInput"

    invoke-virtual {v3}, Ljava/io/IOException;->getMessage()Ljava/lang/String;

    move-result-object v9

    invoke-static {v8, v9}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_4

    .line 116
    .end local v3    # "ioe":Ljava/io/IOException;
    .end local v5    # "output":Ljava/io/OutputStream;
    .restart local v6    # "output":Ljava/io/OutputStream;
    :catchall_1
    move-exception v7

    move-object v5, v6

    .end local v6    # "output":Ljava/io/OutputStream;
    .restart local v5    # "output":Ljava/io/OutputStream;
    goto :goto_3

    .line 113
    :catch_4
    move-exception v1

    goto :goto_1
.end method
