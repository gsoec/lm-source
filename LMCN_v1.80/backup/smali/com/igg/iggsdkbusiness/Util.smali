.class public Lcom/igg/iggsdkbusiness/Util;
.super Ljava/lang/Object;
.source "Util.java"


# static fields
.field private static final MAX_DECODE_PICTURE_SIZE:I = 0x2a3000

.field private static final TAG:Ljava/lang/String; = "SDK_Sample.Util"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static bmpToByteArray(Landroid/graphics/Bitmap;Z)[B
    .locals 5
    .param p0, "bmp"    # Landroid/graphics/Bitmap;
    .param p1, "needRecycle"    # Z

    .prologue
    .line 25
    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 26
    .local v1, "output":Ljava/io/ByteArrayOutputStream;
    sget-object v3, Landroid/graphics/Bitmap$CompressFormat;->PNG:Landroid/graphics/Bitmap$CompressFormat;

    const/16 v4, 0x64

    invoke-virtual {p0, v3, v4, v1}, Landroid/graphics/Bitmap;->compress(Landroid/graphics/Bitmap$CompressFormat;ILjava/io/OutputStream;)Z

    .line 27
    if-eqz p1, :cond_0

    .line 28
    invoke-virtual {p0}, Landroid/graphics/Bitmap;->recycle()V

    .line 31
    :cond_0
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v2

    .line 33
    .local v2, "result":[B
    :try_start_0
    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .line 38
    :goto_0
    return-object v2

    .line 34
    :catch_0
    move-exception v0

    .line 35
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    goto :goto_0
.end method

.method public static extractThumbNail(Ljava/lang/String;IIZ)Landroid/graphics/Bitmap;
    .locals 18
    .param p0, "path"    # Ljava/lang/String;
    .param p1, "height"    # I
    .param p2, "width"    # I
    .param p3, "crop"    # Z

    .prologue
    .line 126
    if-eqz p0, :cond_3

    const-string v14, ""

    move-object/from16 v0, p0

    invoke-virtual {v0, v14}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v14

    if-nez v14, :cond_3

    if-lez p1, :cond_3

    if-lez p2, :cond_3

    const/4 v14, 0x1

    :goto_0
    invoke-static {v14}, Ljunit/framework/Assert;->assertTrue(Z)V

    .line 128
    new-instance v11, Landroid/graphics/BitmapFactory$Options;

    invoke-direct {v11}, Landroid/graphics/BitmapFactory$Options;-><init>()V

    .line 131
    .local v11, "options":Landroid/graphics/BitmapFactory$Options;
    const/4 v14, 0x1

    :try_start_0
    iput-boolean v14, v11, Landroid/graphics/BitmapFactory$Options;->inJustDecodeBounds:Z

    .line 132
    move-object/from16 v0, p0

    invoke-static {v0, v11}, Landroid/graphics/BitmapFactory;->decodeFile(Ljava/lang/String;Landroid/graphics/BitmapFactory$Options;)Landroid/graphics/Bitmap;

    move-result-object v13

    .line 133
    .local v13, "tmp":Landroid/graphics/Bitmap;
    if-eqz v13, :cond_0

    .line 134
    invoke-virtual {v13}, Landroid/graphics/Bitmap;->recycle()V

    .line 135
    const/4 v13, 0x0

    .line 138
    :cond_0
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "extractThumbNail: round="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    move/from16 v0, p2

    invoke-virtual {v15, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, "x"

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    move/from16 v0, p1

    invoke-virtual {v15, v0}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, ", crop="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    move/from16 v0, p3

    invoke-virtual {v15, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 139
    iget v14, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    int-to-double v14, v14

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    move/from16 v0, p1

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v4, v14, v16

    .line 140
    .local v4, "beY":D
    iget v14, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    int-to-double v14, v14

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    move/from16 v0, p2

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v2, v14, v16

    .line 141
    .local v2, "beX":D
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "extractThumbNail: extract beX = "

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15, v2, v3}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, ", beY = "

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15, v4, v5}, Ljava/lang/StringBuilder;->append(D)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 142
    if-eqz p3, :cond_5

    cmpl-double v14, v4, v2

    if-lez v14, :cond_4

    move-wide v14, v2

    :goto_1
    double-to-int v14, v14

    iput v14, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    .line 143
    iget v14, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    const/4 v15, 0x1

    if-gt v14, v15, :cond_1

    .line 144
    const/4 v14, 0x1

    iput v14, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    .line 148
    :cond_1
    :goto_2
    iget v14, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    iget v15, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    mul-int/2addr v14, v15

    iget v15, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    div-int/2addr v14, v15

    const v15, 0x2a3000

    if-le v14, v15, :cond_7

    .line 149
    iget v14, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    add-int/lit8 v14, v14, 0x1

    iput v14, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I
    :try_end_0
    .catch Ljava/lang/OutOfMemoryError; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_2

    .line 196
    .end local v2    # "beX":D
    .end local v4    # "beY":D
    .end local v13    # "tmp":Landroid/graphics/Bitmap;
    :catch_0
    move-exception v8

    .line 197
    .local v8, "e":Ljava/lang/OutOfMemoryError;
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "decode bitmap failed: "

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v8}, Ljava/lang/OutOfMemoryError;->getMessage()Ljava/lang/String;

    move-result-object v16

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 198
    const/4 v11, 0x0

    .line 201
    const/4 v6, 0x0

    .end local v8    # "e":Ljava/lang/OutOfMemoryError;
    :cond_2
    :goto_3
    return-object v6

    .line 126
    .end local v11    # "options":Landroid/graphics/BitmapFactory$Options;
    :cond_3
    const/4 v14, 0x0

    goto/16 :goto_0

    .restart local v2    # "beX":D
    .restart local v4    # "beY":D
    .restart local v11    # "options":Landroid/graphics/BitmapFactory$Options;
    .restart local v13    # "tmp":Landroid/graphics/Bitmap;
    :cond_4
    move-wide v14, v4

    .line 142
    goto :goto_1

    :cond_5
    cmpg-double v14, v4, v2

    if-gez v14, :cond_6

    move-wide v14, v2

    goto :goto_1

    :cond_6
    move-wide v14, v4

    goto :goto_1

    .line 152
    :cond_7
    move/from16 v9, p1

    .line 153
    .local v9, "newHeight":I
    move/from16 v10, p2

    .line 154
    .local v10, "newWidth":I
    if-eqz p3, :cond_9

    .line 155
    cmpl-double v14, v4, v2

    if-lez v14, :cond_8

    .line 156
    int-to-double v14, v10

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    :try_start_1
    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v14, v14, v16

    double-to-int v9, v14

    .line 168
    :goto_4
    const/4 v14, 0x0

    iput-boolean v14, v11, Landroid/graphics/BitmapFactory$Options;->inJustDecodeBounds:Z

    .line 170
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "bitmap required size="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15, v10}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, "x"

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15, v9}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, ", orig="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    move/from16 v16, v0

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, "x"

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    move/from16 v16, v0

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, ", sample="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->inSampleSize:I

    move/from16 v16, v0

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 171
    move-object/from16 v0, p0

    invoke-static {v0, v11}, Landroid/graphics/BitmapFactory;->decodeFile(Ljava/lang/String;Landroid/graphics/BitmapFactory$Options;)Landroid/graphics/Bitmap;

    move-result-object v6

    .line 172
    .local v6, "bm":Landroid/graphics/Bitmap;
    if-nez v6, :cond_b

    .line 173
    const-string v14, "SDK_Sample.Util"

    const-string v15, "bitmap decode failed"

    invoke-static {v14, v15}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 174
    const/4 v6, 0x0

    goto/16 :goto_3

    .line 158
    .end local v6    # "bm":Landroid/graphics/Bitmap;
    :cond_8
    int-to-double v14, v9

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v14, v14, v16

    double-to-int v10, v14

    goto :goto_4

    .line 161
    :cond_9
    cmpg-double v14, v4, v2

    if-gez v14, :cond_a

    .line 162
    int-to-double v14, v10

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v14, v14, v16

    double-to-int v9, v14

    goto/16 :goto_4

    .line 164
    :cond_a
    int-to-double v14, v9

    const-wide/high16 v16, 0x3ff0000000000000L    # 1.0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outWidth:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    mul-double v14, v14, v16

    iget v0, v11, Landroid/graphics/BitmapFactory$Options;->outHeight:I

    move/from16 v16, v0

    move/from16 v0, v16

    int-to-double v0, v0

    move-wide/from16 v16, v0

    div-double v14, v14, v16

    double-to-int v10, v14

    goto/16 :goto_4

    .line 177
    .restart local v6    # "bm":Landroid/graphics/Bitmap;
    :cond_b
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "bitmap decoded size="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v16

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, "x"

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v16

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 178
    const/4 v14, 0x1

    invoke-static {v6, v10, v9, v14}, Landroid/graphics/Bitmap;->createScaledBitmap(Landroid/graphics/Bitmap;IIZ)Landroid/graphics/Bitmap;

    move-result-object v12

    .line 179
    .local v12, "scale":Landroid/graphics/Bitmap;
    if-eqz v12, :cond_c

    .line 180
    invoke-virtual {v6}, Landroid/graphics/Bitmap;->recycle()V

    .line 181
    move-object v6, v12

    .line 184
    :cond_c
    if-eqz p3, :cond_2

    .line 185
    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v14

    sub-int v14, v14, p2

    shr-int/lit8 v14, v14, 0x1

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v15

    sub-int v15, v15, p1

    shr-int/lit8 v15, v15, 0x1

    move/from16 v0, p2

    move/from16 v1, p1

    invoke-static {v6, v14, v15, v0, v1}, Landroid/graphics/Bitmap;->createBitmap(Landroid/graphics/Bitmap;IIII)Landroid/graphics/Bitmap;

    move-result-object v7

    .line 186
    .local v7, "cropped":Landroid/graphics/Bitmap;
    if-eqz v7, :cond_2

    .line 190
    invoke-virtual {v6}, Landroid/graphics/Bitmap;->recycle()V

    .line 191
    move-object v6, v7

    .line 192
    const-string v14, "SDK_Sample.Util"

    new-instance v15, Ljava/lang/StringBuilder;

    invoke-direct {v15}, Ljava/lang/StringBuilder;-><init>()V

    const-string v16, "bitmap croped size="

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getWidth()I

    move-result v16

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    const-string v16, "x"

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v6}, Landroid/graphics/Bitmap;->getHeight()I

    move-result v16

    invoke-virtual/range {v15 .. v16}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v15

    invoke-virtual {v15}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v15

    invoke-static {v14, v15}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I
    :try_end_1
    .catch Ljava/lang/OutOfMemoryError; {:try_start_1 .. :try_end_1} :catch_0

    goto/16 :goto_3
.end method

.method public static getHtmlByteArray(Ljava/lang/String;)[B
    .locals 10
    .param p0, "url"    # Ljava/lang/String;

    .prologue
    .line 42
    const/4 v4, 0x0

    .line 43
    .local v4, "htmlUrl":Ljava/net/URL;
    const/4 v7, 0x0

    .line 45
    .local v7, "inStream":Ljava/io/InputStream;
    :try_start_0
    new-instance v5, Ljava/net/URL;

    invoke-direct {v5, p0}, Ljava/net/URL;-><init>(Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/net/MalformedURLException; {:try_start_0 .. :try_end_0} :catch_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_1

    .line 46
    .end local v4    # "htmlUrl":Ljava/net/URL;
    .local v5, "htmlUrl":Ljava/net/URL;
    :try_start_1
    invoke-virtual {v5}, Ljava/net/URL;->openConnection()Ljava/net/URLConnection;

    move-result-object v1

    .line 47
    .local v1, "connection":Ljava/net/URLConnection;
    move-object v0, v1

    check-cast v0, Ljava/net/HttpURLConnection;

    move-object v6, v0

    .line 48
    .local v6, "httpConnection":Ljava/net/HttpURLConnection;
    invoke-virtual {v6}, Ljava/net/HttpURLConnection;->getResponseCode()I

    move-result v8

    .line 49
    .local v8, "responseCode":I
    const/16 v9, 0xc8

    if-ne v8, v9, :cond_0

    .line 50
    invoke-virtual {v6}, Ljava/net/HttpURLConnection;->getInputStream()Ljava/io/InputStream;
    :try_end_1
    .catch Ljava/net/MalformedURLException; {:try_start_1 .. :try_end_1} :catch_3
    .catch Ljava/io/IOException; {:try_start_1 .. :try_end_1} :catch_2

    move-result-object v7

    :cond_0
    move-object v4, v5

    .line 57
    .end local v1    # "connection":Ljava/net/URLConnection;
    .end local v5    # "htmlUrl":Ljava/net/URL;
    .end local v6    # "httpConnection":Ljava/net/HttpURLConnection;
    .end local v8    # "responseCode":I
    .restart local v4    # "htmlUrl":Ljava/net/URL;
    :goto_0
    invoke-static {v7}, Lcom/igg/iggsdkbusiness/Util;->inputStreamToByte(Ljava/io/InputStream;)[B

    move-result-object v2

    .line 59
    .local v2, "data":[B
    return-object v2

    .line 52
    .end local v2    # "data":[B
    :catch_0
    move-exception v3

    .line 53
    .local v3, "e":Ljava/net/MalformedURLException;
    :goto_1
    invoke-virtual {v3}, Ljava/net/MalformedURLException;->printStackTrace()V

    goto :goto_0

    .line 54
    .end local v3    # "e":Ljava/net/MalformedURLException;
    :catch_1
    move-exception v3

    .line 55
    .local v3, "e":Ljava/io/IOException;
    :goto_2
    invoke-virtual {v3}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_0

    .line 54
    .end local v3    # "e":Ljava/io/IOException;
    .end local v4    # "htmlUrl":Ljava/net/URL;
    .restart local v5    # "htmlUrl":Ljava/net/URL;
    :catch_2
    move-exception v3

    move-object v4, v5

    .end local v5    # "htmlUrl":Ljava/net/URL;
    .restart local v4    # "htmlUrl":Ljava/net/URL;
    goto :goto_2

    .line 52
    .end local v4    # "htmlUrl":Ljava/net/URL;
    .restart local v5    # "htmlUrl":Ljava/net/URL;
    :catch_3
    move-exception v3

    move-object v4, v5

    .end local v5    # "htmlUrl":Ljava/net/URL;
    .restart local v4    # "htmlUrl":Ljava/net/URL;
    goto :goto_1
.end method

.method public static inputStreamToByte(Ljava/io/InputStream;)[B
    .locals 5
    .param p0, "is"    # Ljava/io/InputStream;

    .prologue
    .line 64
    :try_start_0
    new-instance v0, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v0}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 66
    .local v0, "bytestream":Ljava/io/ByteArrayOutputStream;
    :goto_0
    invoke-virtual {p0}, Ljava/io/InputStream;->read()I

    move-result v1

    .local v1, "ch":I
    const/4 v4, -0x1

    if-eq v1, v4, :cond_0

    .line 67
    invoke-virtual {v0, v1}, Ljava/io/ByteArrayOutputStream;->write(I)V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto :goto_0

    .line 72
    .end local v0    # "bytestream":Ljava/io/ByteArrayOutputStream;
    .end local v1    # "ch":I
    :catch_0
    move-exception v2

    .line 73
    .local v2, "e":Ljava/lang/Exception;
    invoke-virtual {v2}, Ljava/lang/Exception;->printStackTrace()V

    .line 76
    const/4 v3, 0x0

    .end local v2    # "e":Ljava/lang/Exception;
    :goto_1
    return-object v3

    .line 69
    .restart local v0    # "bytestream":Ljava/io/ByteArrayOutputStream;
    .restart local v1    # "ch":I
    :cond_0
    :try_start_1
    invoke-virtual {v0}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v3

    .line 70
    .local v3, "imgdata":[B
    invoke-virtual {v0}, Ljava/io/ByteArrayOutputStream;->close()V
    :try_end_1
    .catch Ljava/lang/Exception; {:try_start_1 .. :try_end_1} :catch_0

    goto :goto_1
.end method

.method public static readFromFile(Ljava/lang/String;II)[B
    .locals 8
    .param p0, "fileName"    # Ljava/lang/String;
    .param p1, "offset"    # I
    .param p2, "len"    # I

    .prologue
    const/4 v0, 0x0

    .line 80
    if-nez p0, :cond_0

    .line 121
    :goto_0
    return-object v0

    .line 84
    :cond_0
    new-instance v2, Ljava/io/File;

    invoke-direct {v2, p0}, Ljava/io/File;-><init>(Ljava/lang/String;)V

    .line 85
    .local v2, "file":Ljava/io/File;
    invoke-virtual {v2}, Ljava/io/File;->exists()Z

    move-result v4

    if-nez v4, :cond_1

    .line 86
    const-string v4, "SDK_Sample.Util"

    const-string v5, "readFromFile: file not found"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 90
    :cond_1
    const/4 v4, -0x1

    if-ne p2, v4, :cond_2

    .line 91
    invoke-virtual {v2}, Ljava/io/File;->length()J

    move-result-wide v4

    long-to-int p2, v4

    .line 94
    :cond_2
    const-string v4, "SDK_Sample.Util"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "readFromFile : offset = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, " len = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    const-string v6, " offset + len = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    add-int v6, p1, p2

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->d(Ljava/lang/String;Ljava/lang/String;)I

    .line 96
    if-gez p1, :cond_3

    .line 97
    const-string v4, "SDK_Sample.Util"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "readFromFile invalid offset:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 100
    :cond_3
    if-gtz p2, :cond_4

    .line 101
    const-string v4, "SDK_Sample.Util"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "readFromFile invalid len:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5, p2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0

    .line 104
    :cond_4
    add-int v4, p1, p2

    invoke-virtual {v2}, Ljava/io/File;->length()J

    move-result-wide v6

    long-to-int v5, v6

    if-le v4, v5, :cond_5

    .line 105
    const-string v4, "SDK_Sample.Util"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "readFromFile invalid file len:"

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v2}, Ljava/io/File;->length()J

    move-result-wide v6

    invoke-virtual {v5, v6, v7}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    goto/16 :goto_0

    .line 109
    :cond_5
    const/4 v0, 0x0

    .line 111
    .local v0, "b":[B
    :try_start_0
    new-instance v3, Ljava/io/RandomAccessFile;

    const-string v4, "r"

    invoke-direct {v3, p0, v4}, Ljava/io/RandomAccessFile;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    .line 112
    .local v3, "in":Ljava/io/RandomAccessFile;
    new-array v0, p2, [B

    .line 113
    int-to-long v4, p1

    invoke-virtual {v3, v4, v5}, Ljava/io/RandomAccessFile;->seek(J)V

    .line 114
    invoke-virtual {v3, v0}, Ljava/io/RandomAccessFile;->readFully([B)V

    .line 115
    invoke-virtual {v3}, Ljava/io/RandomAccessFile;->close()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    goto/16 :goto_0

    .line 117
    .end local v3    # "in":Ljava/io/RandomAccessFile;
    :catch_0
    move-exception v1

    .line 118
    .local v1, "e":Ljava/lang/Exception;
    const-string v4, "SDK_Sample.Util"

    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    const-string v6, "readFromFile : errMsg = "

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v1}, Ljava/lang/Exception;->getMessage()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v5

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-static {v4, v5}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 119
    invoke-virtual {v1}, Ljava/lang/Exception;->printStackTrace()V

    goto/16 :goto_0
.end method
