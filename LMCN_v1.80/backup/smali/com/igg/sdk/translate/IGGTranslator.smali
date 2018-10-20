.class public Lcom/igg/sdk/translate/IGGTranslator;
.super Ljava/lang/Object;
.source "IGGTranslator.java"


# static fields
.field private static final SERVER_RETURN_HANDLE_DATA_ERROR:I = 0x186a8

.field private static final TAG:Ljava/lang/String; = "IGGTranslator"


# instance fields
.field private detect:I

.field private gameId:Ljava/lang/String;

.field private iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

.field private sourceLanguage:Ljava/lang/String;

.field private targetLanguage:Ljava/lang/String;

.field private timeout:I

.field private translatorSecretKey:Ljava/lang/String;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V
    .locals 2
    .param p1, "iggIDC"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .param p2, "gameId"    # Ljava/lang/String;
    .param p3, "sourceLanguage"    # Ljava/lang/String;
    .param p4, "targetLanguage"    # Ljava/lang/String;

    .prologue
    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    iput-object p1, p0, Lcom/igg/sdk/translate/IGGTranslator;->iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 47
    iput-object p2, p0, Lcom/igg/sdk/translate/IGGTranslator;->gameId:Ljava/lang/String;

    .line 48
    iput-object p3, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    .line 49
    iput-object p4, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    .line 50
    if-nez p3, :cond_0

    .line 51
    const/4 v1, 0x1

    iput v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    .line 55
    :goto_0
    new-instance v0, Lcom/igg/util/IGGSecretKeyHelper;

    invoke-direct {v0}, Lcom/igg/util/IGGSecretKeyHelper;-><init>()V

    .line 56
    .local v0, "helper":Lcom/igg/util/IGGSecretKeyHelper;
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getSecretKey()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/util/IGGSecretKeyHelper;->mix(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->translatorSecretKey:Ljava/lang/String;

    .line 57
    return-void

    .line 53
    .end local v0    # "helper":Lcom/igg/util/IGGSecretKeyHelper;
    :cond_0
    const/4 v1, 0x0

    iput v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    goto :goto_0
.end method

.method static synthetic access$000(Lcom/igg/sdk/translate/IGGTranslator;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 27
    iget v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    return v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 27
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic access$200(Lcom/igg/sdk/translate/IGGTranslator;)Ljava/lang/String;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/translate/IGGTranslator;

    .prologue
    .line 27
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    return-object v0
.end method

.method private formateIGGTranslationNamedSourceListToString(Ljava/util/List;)Ljava/lang/String;
    .locals 10
    .param p1    # Ljava/util/List;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationNamedSource;",
            ">;)",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 306
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationNamedSource;>;"
    const-string v5, ""

    .line 309
    .local v5, "ret":Ljava/lang/String;
    :try_start_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v4

    .line 310
    .local v4, "len":I
    new-instance v2, Lorg/json/JSONArray;

    invoke-direct {v2}, Lorg/json/JSONArray;-><init>()V

    .line 311
    .local v2, "jsonArray":Lorg/json/JSONArray;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    if-ge v1, v4, :cond_0

    .line 312
    new-instance v3, Lorg/json/JSONObject;

    invoke-direct {v3}, Lorg/json/JSONObject;-><init>()V

    .line 313
    .local v3, "jsonObject":Lorg/json/JSONObject;
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v6

    check-cast v6, Lcom/igg/sdk/translate/IGGTranslationNamedSource;

    .line 314
    .local v6, "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    invoke-virtual {v6}, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->getName()Ljava/lang/String;

    move-result-object v7

    invoke-virtual {v6}, Lcom/igg/sdk/translate/IGGTranslationNamedSource;->getText()Ljava/lang/String;

    move-result-object v8

    invoke-virtual {v3, v7, v8}, Lorg/json/JSONObject;->put(Ljava/lang/String;Ljava/lang/Object;)Lorg/json/JSONObject;

    .line 315
    invoke-virtual {v2, v3}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    .line 311
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 318
    .end local v3    # "jsonObject":Lorg/json/JSONObject;
    .end local v6    # "translationNamedSource":Lcom/igg/sdk/translate/IGGTranslationNamedSource;
    :cond_0
    const-string v7, "IGGTranslator"

    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    const-string v9, "jsonArray.toString():"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v2}, Lorg/json/JSONArray;->toString()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v8

    invoke-static {v7, v8}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 319
    invoke-virtual {v2}, Lorg/json/JSONArray;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v5

    .line 324
    .end local v1    # "i":I
    .end local v2    # "jsonArray":Lorg/json/JSONArray;
    .end local v4    # "len":I
    :goto_1
    return-object v5

    .line 320
    :catch_0
    move-exception v0

    .line 321
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 322
    const-string v5, ""

    goto :goto_1
.end method

.method private formateIGGTranslationSourceListToString(Ljava/util/List;)Ljava/lang/String;
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;)",
            "Ljava/lang/String;"
        }
    .end annotation

    .prologue
    .line 353
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    const-string v4, ""

    .line 356
    .local v4, "ret":Ljava/lang/String;
    :try_start_0
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v3

    .line 357
    .local v3, "len":I
    new-instance v2, Lorg/json/JSONArray;

    invoke-direct {v2}, Lorg/json/JSONArray;-><init>()V

    .line 358
    .local v2, "jsonArray":Lorg/json/JSONArray;
    const/4 v1, 0x0

    .local v1, "i":I
    :goto_0
    if-ge v1, v3, :cond_0

    .line 359
    invoke-interface {p1, v1}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Lcom/igg/sdk/translate/IGGTranslationSource;

    .line 360
    .local v5, "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    invoke-virtual {v5}, Lcom/igg/sdk/translate/IGGTranslationSource;->getText()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v2, v6}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    .line 358
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 362
    .end local v5    # "translationSource":Lcom/igg/sdk/translate/IGGTranslationSource;
    :cond_0
    invoke-virtual {v2}, Lorg/json/JSONArray;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v4

    .line 367
    .end local v1    # "i":I
    .end local v2    # "jsonArray":Lorg/json/JSONArray;
    .end local v3    # "len":I
    :goto_1
    return-object v4

    .line 363
    :catch_0
    move-exception v0

    .line 364
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 365
    const-string v4, ""

    goto :goto_1
.end method

.method private formateIGGTranslationSourceToString(Lcom/igg/sdk/translate/IGGTranslationSource;)Ljava/lang/String;
    .locals 6
    .param p1, "translationSource"    # Lcom/igg/sdk/translate/IGGTranslationSource;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    .line 333
    const-string v2, ""

    .line 336
    .local v2, "ret":Ljava/lang/String;
    :try_start_0
    new-instance v1, Lorg/json/JSONArray;

    invoke-direct {v1}, Lorg/json/JSONArray;-><init>()V

    .line 337
    .local v1, "jsonArray":Lorg/json/JSONArray;
    invoke-virtual {p1}, Lcom/igg/sdk/translate/IGGTranslationSource;->getText()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v3}, Lorg/json/JSONArray;->put(Ljava/lang/Object;)Lorg/json/JSONArray;

    .line 338
    const-string v3, "IGGTranslator"

    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "texts:"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v1}, Lorg/json/JSONArray;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 339
    invoke-virtual {v1}, Lorg/json/JSONArray;->toString()Ljava/lang/String;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v2

    .line 344
    .end local v1    # "jsonArray":Lorg/json/JSONArray;
    :goto_0
    return-object v2

    .line 340
    :catch_0
    move-exception v0

    .line 341
    .local v0, "e":Ljava/lang/Exception;
    invoke-virtual {v0}, Ljava/lang/Exception;->printStackTrace()V

    .line 342
    const-string v2, ""

    goto :goto_0
.end method

.method private generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;)Ljava/util/HashMap;
    .locals 8
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "sourceLanguage"    # Ljava/lang/String;
    .param p3, "targetLanguage"    # Ljava/lang/String;
    .param p4, "detect"    # I
    .param p5, "texts"    # Ljava/lang/String;
    .param p6, "secretKey"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "I",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ")",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 258
    const/4 v7, 0x0

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v3, p3

    move v4, p4

    move-object v5, p5

    move-object v6, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/sdk/translate/IGGTranslator;->generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;Z)Ljava/util/HashMap;

    move-result-object v0

    return-object v0
.end method

.method private generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;Z)Ljava/util/HashMap;
    .locals 8
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "sourceLanguage"    # Ljava/lang/String;
    .param p3, "targetLanguage"    # Ljava/lang/String;
    .param p4, "detect"    # I
    .param p5, "texts"    # Ljava/lang/String;
    .param p6, "secretKey"    # Ljava/lang/String;
    .param p7, "isDebug"    # Z
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "I",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Z)",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .prologue
    .line 275
    new-instance v1, Ljava/util/HashMap;

    invoke-direct {v1}, Ljava/util/HashMap;-><init>()V

    .line 276
    .local v1, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v2, "gameId"

    invoke-virtual {v1, v2, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 277
    const-string v2, "source"

    invoke-virtual {v1, v2, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 278
    const-string v2, "target"

    invoke-virtual {v1, v2, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 279
    const/4 v2, 0x1

    if-ne p4, v2, :cond_1

    .line 280
    const-string v2, "detect"

    const-string v3, "1"

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 285
    :goto_0
    const-string v2, "texts"

    invoke-virtual {v1, v2, p5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 287
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v4

    const-wide/16 v6, 0x3e8

    div-long/2addr v4, v6

    invoke-virtual {v2, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v2

    const-string v3, ""

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 288
    .local v0, "currentTimeSecond":Ljava/lang/String;
    const-string v2, "timestamp"

    invoke-virtual {v1, v2, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 291
    const-string v2, "signature"

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v3, p5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    invoke-static {v3, p6}, Lcom/igg/util/SignatureUtils;->hamcMD5(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 293
    if-eqz p7, :cond_0

    .line 294
    const-string v2, "debug"

    const-string v3, ""

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 297
    :cond_0
    return-object v1

    .line 282
    .end local v0    # "currentTimeSecond":Ljava/lang/String;
    :cond_1
    const-string v2, "detect"

    const-string v3, "0"

    invoke-virtual {v1, v2, v3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0
.end method


# virtual methods
.method public getDetect()I
    .locals 1

    .prologue
    .line 435
    iget v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    return v0
.end method

.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 376
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getIGGIDC()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 403
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method

.method public getSourceLanguage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 385
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    return-object v0
.end method

.method public getTargetLanguage()Ljava/lang/String;
    .locals 1

    .prologue
    .line 394
    iget-object v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    return-object v0
.end method

.method public getTimeout()I
    .locals 3

    .prologue
    .line 412
    iget v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->timeout:I

    if-nez v0, :cond_0

    .line 413
    const/16 v0, 0x1388

    iput v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->timeout:I

    .line 416
    :cond_0
    const-string v0, "IGGTranslator"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget v2, p0, Lcom/igg/sdk/translate/IGGTranslator;->timeout:I

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 417
    iget v0, p0, Lcom/igg/sdk/translate/IGGTranslator;->timeout:I

    return v0
.end method

.method public setTimeout(I)V
    .locals 0
    .param p1, "timeout"    # I

    .prologue
    .line 426
    iput p1, p0, Lcom/igg/sdk/translate/IGGTranslator;->timeout:I

    .line 427
    return-void
.end method

.method public translateNamedTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
    .locals 8
    .param p2, "listener"    # Lcom/igg/sdk/translate/IGGTranslatorListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationNamedSource;",
            ">;",
            "Lcom/igg/sdk/translate/IGGTranslatorListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 185
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationNamedSource;>;"
    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->gameId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    iget v4, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    .line 187
    invoke-direct {p0, p1}, Lcom/igg/sdk/translate/IGGTranslator;->formateIGGTranslationNamedSourceListToString(Ljava/util/List;)Ljava/lang/String;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslator;->translatorSecretKey:Ljava/lang/String;

    move-object v0, p0

    .line 185
    invoke-direct/range {v0 .. v6}, Lcom/igg/sdk/translate/IGGTranslator;->generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;)Ljava/util/HashMap;

    move-result-object v7

    .line 188
    .local v7, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getTranslateAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0}, Lcom/igg/sdk/translate/IGGTranslator;->getTimeout()I

    move-result v2

    new-instance v3, Lcom/igg/sdk/translate/IGGTranslator$3;

    invoke-direct {v3, p0, p1, p2}, Lcom/igg/sdk/translate/IGGTranslator$3;-><init>(Lcom/igg/sdk/translate/IGGTranslator;Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    invoke-virtual {v0, v1, v7, v2, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 243
    return-void
.end method

.method public translateText(Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
    .locals 9
    .param p1, "translationSource"    # Lcom/igg/sdk/translate/IGGTranslationSource;
    .param p2, "listener"    # Lcom/igg/sdk/translate/IGGTranslatorListener;

    .prologue
    .line 66
    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->gameId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    iget v4, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    .line 68
    invoke-direct {p0, p1}, Lcom/igg/sdk/translate/IGGTranslator;->formateIGGTranslationSourceToString(Lcom/igg/sdk/translate/IGGTranslationSource;)Ljava/lang/String;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslator;->translatorSecretKey:Ljava/lang/String;

    move-object v0, p0

    .line 66
    invoke-direct/range {v0 .. v6}, Lcom/igg/sdk/translate/IGGTranslator;->generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;)Ljava/util/HashMap;

    move-result-object v8

    .line 70
    .local v8, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v7, Lcom/igg/sdk/translate/IGGTranslator$1;

    invoke-direct {v7, p0, p1, p2}, Lcom/igg/sdk/translate/IGGTranslator$1;-><init>(Lcom/igg/sdk/translate/IGGTranslator;Lcom/igg/sdk/translate/IGGTranslationSource;Lcom/igg/sdk/translate/IGGTranslatorListener;)V

    .line 117
    .local v7, "generalRequestListener":Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getTranslateAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0}, Lcom/igg/sdk/translate/IGGTranslator;->getTimeout()I

    move-result v2

    invoke-virtual {v0, v1, v8, v2, v7}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 118
    return-void
.end method

.method public translateTexts(Ljava/util/List;Lcom/igg/sdk/translate/IGGTranslatorListener;)V
    .locals 8
    .param p2, "listener"    # Lcom/igg/sdk/translate/IGGTranslatorListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List",
            "<",
            "Lcom/igg/sdk/translate/IGGTranslationSource;",
            ">;",
            "Lcom/igg/sdk/translate/IGGTranslatorListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 127
    .local p1, "list":Ljava/util/List;, "Ljava/util/List<Lcom/igg/sdk/translate/IGGTranslationSource;>;"
    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->gameId:Ljava/lang/String;

    iget-object v2, p0, Lcom/igg/sdk/translate/IGGTranslator;->sourceLanguage:Ljava/lang/String;

    iget-object v3, p0, Lcom/igg/sdk/translate/IGGTranslator;->targetLanguage:Ljava/lang/String;

    iget v4, p0, Lcom/igg/sdk/translate/IGGTranslator;->detect:I

    .line 129
    invoke-direct {p0, p1}, Lcom/igg/sdk/translate/IGGTranslator;->formateIGGTranslationSourceListToString(Ljava/util/List;)Ljava/lang/String;

    move-result-object v5

    iget-object v6, p0, Lcom/igg/sdk/translate/IGGTranslator;->translatorSecretKey:Ljava/lang/String;

    move-object v0, p0

    .line 127
    invoke-direct/range {v0 .. v6}, Lcom/igg/sdk/translate/IGGTranslator;->generatePostParameters(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILjava/lang/String;Ljava/lang/String;)Ljava/util/HashMap;

    move-result-object v7

    .line 130
    .local v7, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/translate/IGGTranslator;->iggIDC:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-static {v1}, Lcom/igg/sdk/IGGURLHelper;->getTranslateAPI(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0}, Lcom/igg/sdk/translate/IGGTranslator;->getTimeout()I

    move-result v2

    new-instance v3, Lcom/igg/sdk/translate/IGGTranslator$2;

    invoke-direct {v3, p0, p2, p1}, Lcom/igg/sdk/translate/IGGTranslator$2;-><init>(Lcom/igg/sdk/translate/IGGTranslator;Lcom/igg/sdk/translate/IGGTranslatorListener;Ljava/util/List;)V

    invoke-virtual {v0, v1, v7, v2, v3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 176
    return-void
.end method
