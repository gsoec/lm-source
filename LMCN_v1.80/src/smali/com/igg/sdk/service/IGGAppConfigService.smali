.class public Lcom/igg/sdk/service/IGGAppConfigService;
.super Lcom/igg/sdk/service/IGGService;
.source "IGGAppConfigService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;,
        Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;,
        Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;
    }
.end annotation


# static fields
.field private static final LOADCDN:I = 0x2

.field private static final LOADDEFAULT:I = 0x1

.field private static final LOADSND:I = 0x3

.field private static TAG:Ljava/lang/String;


# instance fields
.field cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

.field configRequestTask:Lcom/igg/util/AsyncTask;

.field defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

.field sndRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

.field private storage:Lcom/igg/util/LocalStorage;

.field timer:Ljava/util/Timer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 36
    const-string v0, "IGGAppConfigService"

    sput-object v0, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 3

    .prologue
    .line 51
    invoke-direct {p0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    .line 38
    new-instance v0, Ljava/util/Timer;

    invoke-direct {v0}, Ljava/util/Timer;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    .line 52
    new-instance v0, Lcom/igg/util/LocalStorage;

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getApplication()Landroid/app/Application;

    move-result-object v1

    const-string v2, "app_config_file"

    invoke-direct {v0, v1, v2}, Lcom/igg/util/LocalStorage;-><init>(Landroid/content/Context;Ljava/lang/String;)V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->storage:Lcom/igg/util/LocalStorage;

    .line 53
    return-void
.end method

.method static synthetic access$000()Ljava/lang/String;
    .locals 1

    .prologue
    .line 34
    sget-object v0, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    return-object v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/service/IGGAppConfigService;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p3, "x3"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    .line 34
    invoke-direct {p0, p1, p2, p3}, Lcom/igg/sdk/service/IGGAppConfigService;->dynamicLoad(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    return-void
.end method

.method static synthetic access$200(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/service/IGGAppConfigService;
    .param p1, "x1"    # Ljava/lang/String;
    .param p2, "x2"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p3, "x3"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    .line 34
    invoke-direct {p0, p1, p2, p3}, Lcom/igg/sdk/service/IGGAppConfigService;->sndLoad(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    return-void
.end method

.method static synthetic access$300(Lcom/igg/sdk/service/IGGAppConfigService;)Lcom/igg/sdk/bean/IGGAppConfig;
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/service/IGGAppConfigService;

    .prologue
    .line 34
    invoke-direct {p0}, Lcom/igg/sdk/service/IGGAppConfigService;->getLocalConfig()Lcom/igg/sdk/bean/IGGAppConfig;

    move-result-object v0

    return-object v0
.end method

.method static synthetic access$400(Lcom/igg/sdk/service/IGGAppConfigService;Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/service/IGGAppConfigService;
    .param p1, "x1"    # Lcom/igg/sdk/error/IGGError;
    .param p2, "x2"    # Ljava/util/Map;
    .param p3, "x3"    # Ljava/lang/String;
    .param p4, "x4"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    .line 34
    invoke-direct {p0, p1, p2, p3, p4}, Lcom/igg/sdk/service/IGGAppConfigService;->setAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    return-void
.end method

.method private dynamicLoad(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 7
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "format"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    const/4 v2, 0x2

    .line 148
    new-instance v6, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

    invoke-direct {v6, p0, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;I)V

    .line 149
    .local v6, "task":Ljava/util/TimerTask;
    new-instance v0, Ljava/util/Timer;

    invoke-direct {v0}, Ljava/util/Timer;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    .line 150
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    const-wide/16 v4, 0x2710

    invoke-virtual {v0, v6, v4, v5}, Ljava/util/Timer;->schedule(Ljava/util/TimerTask;J)V

    .line 151
    new-instance v0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    move-object v1, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;ILjava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->cdnRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    .line 152
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->DYNAMIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-static {p1, p2, v0}, Lcom/igg/sdk/IGGURLHelper;->getAppConfigURL(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/IGGSDKConstant$CDNType;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x0

    const/16 v2, 0x2710

    new-instance v3, Lcom/igg/sdk/service/IGGAppConfigService$2;

    invoke-direct {v3, p0}, Lcom/igg/sdk/service/IGGAppConfigService$2;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;)V

    invoke-virtual {p0, v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGAppConfigService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;

    .line 164
    return-void
.end method

.method private getLocalConfig()Lcom/igg/sdk/bean/IGGAppConfig;
    .locals 9

    .prologue
    .line 369
    const/4 v1, 0x0

    .line 371
    .local v1, "appConfig":Lcom/igg/sdk/bean/IGGAppConfig;
    :try_start_0
    sget-object v7, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    const-string v8, "getLocalConfig"

    invoke-static {v7, v8}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 372
    iget-object v7, p0, Lcom/igg/sdk/service/IGGAppConfigService;->storage:Lcom/igg/util/LocalStorage;

    const-string v8, "app_config"

    invoke-virtual {v7, v8}, Lcom/igg/util/LocalStorage;->readString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    .line 373
    .local v5, "fileObject":Ljava/lang/String;
    if-eqz v5, :cond_0

    const-string v7, ""

    invoke-virtual {v5, v7}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v7

    if-nez v7, :cond_0

    .line 374
    invoke-virtual {v5}, Ljava/lang/String;->getBytes()[B

    move-result-object v7

    invoke-static {v7}, Lcom/igg/util/Base64;->decode([B)[B

    move-result-object v3

    .line 375
    .local v3, "base64Bytes":[B
    new-instance v2, Ljava/io/ByteArrayInputStream;

    invoke-direct {v2, v3}, Ljava/io/ByteArrayInputStream;-><init>([B)V

    .line 376
    .local v2, "bais":Ljava/io/ByteArrayInputStream;
    new-instance v6, Ljava/io/ObjectInputStream;

    invoke-direct {v6, v2}, Ljava/io/ObjectInputStream;-><init>(Ljava/io/InputStream;)V

    .line 377
    .local v6, "ois":Ljava/io/ObjectInputStream;
    invoke-virtual {v6}, Ljava/io/ObjectInputStream;->readObject()Ljava/lang/Object;

    move-result-object v7

    move-object v0, v7

    check-cast v0, Lcom/igg/sdk/bean/IGGAppConfig;

    move-object v1, v0
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    .end local v2    # "bais":Ljava/io/ByteArrayInputStream;
    .end local v3    # "base64Bytes":[B
    .end local v6    # "ois":Ljava/io/ObjectInputStream;
    :cond_0
    move-object v7, v1

    .line 382
    .end local v5    # "fileObject":Ljava/lang/String;
    :goto_0
    return-object v7

    .line 381
    :catch_0
    move-exception v4

    .line 382
    .local v4, "e":Ljava/lang/Exception;
    const/4 v7, 0x0

    goto :goto_0
.end method

.method private saveLocalConfig(Lcom/igg/sdk/bean/IGGAppConfig;)V
    .locals 6
    .param p1, "appConfig"    # Lcom/igg/sdk/bean/IGGAppConfig;

    .prologue
    .line 352
    :try_start_0
    sget-object v4, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    const-string v5, "saveLocalConfig"

    invoke-static {v4, v5}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 353
    new-instance v0, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v0}, Ljava/io/ByteArrayOutputStream;-><init>()V

    .line 354
    .local v0, "baos":Ljava/io/ByteArrayOutputStream;
    new-instance v2, Ljava/io/ObjectOutputStream;

    invoke-direct {v2, v0}, Ljava/io/ObjectOutputStream;-><init>(Ljava/io/OutputStream;)V

    .line 355
    .local v2, "oos":Ljava/io/ObjectOutputStream;
    invoke-virtual {v2, p1}, Ljava/io/ObjectOutputStream;->writeObject(Ljava/lang/Object;)V

    .line 356
    new-instance v3, Ljava/lang/String;

    invoke-virtual {v0}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v4

    invoke-static {v4}, Lcom/igg/util/Base64;->encode([B)Ljava/lang/String;

    move-result-object v4

    invoke-direct {v3, v4}, Ljava/lang/String;-><init>(Ljava/lang/String;)V

    .line 357
    .local v3, "personBase64":Ljava/lang/String;
    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService;->storage:Lcom/igg/util/LocalStorage;

    const-string v5, "app_config"

    invoke-virtual {v4, v5, v3}, Lcom/igg/util/LocalStorage;->writeString(Ljava/lang/String;Ljava/lang/String;)V
    :try_end_0
    .catch Ljava/io/IOException; {:try_start_0 .. :try_end_0} :catch_0

    .line 361
    .end local v0    # "baos":Ljava/io/ByteArrayOutputStream;
    .end local v2    # "oos":Ljava/io/ObjectOutputStream;
    .end local v3    # "personBase64":Ljava/lang/String;
    :goto_0
    return-void

    .line 358
    :catch_0
    move-exception v1

    .line 359
    .local v1, "e":Ljava/io/IOException;
    invoke-virtual {v1}, Ljava/io/IOException;->printStackTrace()V

    goto :goto_0
.end method

.method private setAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 16
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p3, "responseString"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/igg/sdk/error/IGGError;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;>;",
            "Ljava/lang/String;",
            "Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 290
    .local p2, "headersMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    new-instance v2, Lcom/igg/sdk/bean/IGGAppConfig;

    invoke-direct {v2}, Lcom/igg/sdk/bean/IGGAppConfig;-><init>()V

    .line 291
    .local v2, "appConfig":Lcom/igg/sdk/bean/IGGAppConfig;
    move-object/from16 v0, p3

    invoke-virtual {v2, v0}, Lcom/igg/sdk/bean/IGGAppConfig;->setRawString(Ljava/lang/String;)V

    .line 292
    const-string v13, "X-IGG"

    move-object/from16 v0, p2

    invoke-interface {v0, v13}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Ljava/util/List;

    .line 293
    .local v4, "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    const/4 v13, 0x0

    invoke-interface {v4, v13}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v5

    check-cast v5, Ljava/lang/String;

    .line 294
    .local v5, "headerValues":Ljava/lang/String;
    if-eqz v5, :cond_2

    const-string v13, ""

    invoke-virtual {v5, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-nez v13, :cond_2

    .line 295
    const-string v13, ";"

    invoke-virtual {v5, v13}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v11

    .line 296
    .local v11, "strArray":[Ljava/lang/String;
    if-eqz v11, :cond_2

    array-length v13, v11

    if-lez v13, :cond_2

    .line 297
    const/4 v13, 0x0

    aget-object v7, v11, v13

    .line 298
    .local v7, "info":Ljava/lang/String;
    const-string v13, ","

    invoke-virtual {v7, v13}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v8

    .line 300
    .local v8, "infoArray":[Ljava/lang/String;
    if-eqz v8, :cond_1

    array-length v13, v8

    if-lez v13, :cond_1

    .line 301
    const/4 v13, 0x0

    aget-object v13, v8, v13

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setProtocolNumber(Ljava/lang/String;)V

    .line 303
    const/4 v13, 0x1

    aget-object v13, v8, v13

    invoke-static {v13}, Ljava/lang/Integer;->parseInt(Ljava/lang/String;)I

    move-result v6

    .line 304
    .local v6, "id":I
    invoke-virtual {v2, v6}, Lcom/igg/sdk/bean/IGGAppConfig;->setId(I)V

    .line 306
    const/4 v13, 0x2

    aget-object v13, v8, v13

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setUpdateAt(Ljava/lang/String;)V

    .line 308
    const/4 v13, 0x3

    aget-object v12, v8, v13

    .line 309
    .local v12, "val":Ljava/lang/String;
    const-string v13, "21"

    invoke-virtual {v12, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_3

    .line 310
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->REMOTE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setSource(Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;)V

    .line 318
    :cond_0
    :goto_0
    const/4 v13, 0x4

    aget-object v9, v8, v13

    .line 319
    .local v9, "nodeVal":Ljava/lang/String;
    const-string v13, "SG"

    invoke-virtual {v9, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_5

    .line 320
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SG:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setNode(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    .line 331
    .end local v6    # "id":I
    .end local v9    # "nodeVal":Ljava/lang/String;
    .end local v12    # "val":Ljava/lang/String;
    :cond_1
    :goto_1
    const/4 v13, 0x1

    aget-object v13, v11, v13

    const-string v14, "="

    invoke-virtual {v13, v14}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v10

    .line 332
    .local v10, "serviceArray":[Ljava/lang/String;
    sget-object v13, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    new-instance v14, Ljava/lang/StringBuilder;

    invoke-direct {v14}, Ljava/lang/StringBuilder;-><init>()V

    const-string v15, "serviceTime:"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const/4 v15, 0x1

    aget-object v15, v10, v15

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-static {v13, v14}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 333
    const/4 v13, 0x1

    aget-object v13, v10, v13

    invoke-static {v13}, Ljava/lang/Long;->parseLong(Ljava/lang/String;)J

    move-result-wide v14

    invoke-virtual {v2, v14, v15}, Lcom/igg/sdk/bean/IGGAppConfig;->setServerTimestamp(J)V

    .line 335
    const/4 v13, 0x2

    aget-object v13, v11, v13

    const-string v14, "="

    invoke-virtual {v13, v14}, Ljava/lang/String;->split(Ljava/lang/String;)[Ljava/lang/String;

    move-result-object v3

    .line 336
    .local v3, "clientInfo":[Ljava/lang/String;
    sget-object v13, Lcom/igg/sdk/service/IGGAppConfigService;->TAG:Ljava/lang/String;

    new-instance v14, Ljava/lang/StringBuilder;

    invoke-direct {v14}, Ljava/lang/StringBuilder;-><init>()V

    const-string v15, "ip:"

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    const/4 v15, 0x1

    aget-object v15, v3, v15

    invoke-virtual {v14, v15}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v14

    invoke-virtual {v14}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v14

    invoke-static {v13, v14}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 337
    const/4 v13, 0x1

    aget-object v13, v3, v13

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setClientIp(Ljava/lang/String;)V

    .line 341
    .end local v3    # "clientInfo":[Ljava/lang/String;
    .end local v7    # "info":Ljava/lang/String;
    .end local v8    # "infoArray":[Ljava/lang/String;
    .end local v10    # "serviceArray":[Ljava/lang/String;
    .end local v11    # "strArray":[Ljava/lang/String;
    :cond_2
    move-object/from16 v0, p0

    invoke-direct {v0, v2}, Lcom/igg/sdk/service/IGGAppConfigService;->saveLocalConfig(Lcom/igg/sdk/bean/IGGAppConfig;)V

    .line 342
    move-object/from16 v0, p4

    move-object/from16 v1, p1

    invoke-interface {v0, v1, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;->onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V

    .line 343
    return-void

    .line 311
    .restart local v6    # "id":I
    .restart local v7    # "info":Ljava/lang/String;
    .restart local v8    # "infoArray":[Ljava/lang/String;
    .restart local v11    # "strArray":[Ljava/lang/String;
    .restart local v12    # "val":Ljava/lang/String;
    :cond_3
    const-string v13, "11"

    invoke-virtual {v12, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_4

    .line 312
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->LOCAL:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setSource(Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;)V

    goto/16 :goto_0

    .line 313
    :cond_4
    const-string v13, "12"

    invoke-virtual {v12, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_0

    .line 314
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;->RESCUE:Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setSource(Lcom/igg/sdk/IGGSDKConstant$IGGAppSource;)V

    goto/16 :goto_0

    .line 321
    .restart local v9    # "nodeVal":Ljava/lang/String;
    :cond_5
    const-string v13, "SND"

    invoke-virtual {v9, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_6

    .line 322
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->SND:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setNode(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_1

    .line 323
    :cond_6
    const-string v13, "TW"

    invoke-virtual {v9, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_7

    .line 324
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->TW:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setNode(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_1

    .line 325
    :cond_7
    const-string v13, "EU"

    invoke-virtual {v9, v13}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v13

    if-eqz v13, :cond_1

    .line 326
    sget-object v13, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->EU:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v2, v13}, Lcom/igg/sdk/bean/IGGAppConfig;->setNode(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V

    goto/16 :goto_1
.end method

.method private sndLoad(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 7
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "format"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    const/4 v2, 0x3

    .line 174
    new-instance v6, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

    invoke-direct {v6, p0, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;I)V

    .line 175
    .local v6, "task":Ljava/util/TimerTask;
    new-instance v0, Ljava/util/Timer;

    invoke-direct {v0}, Ljava/util/Timer;-><init>()V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    .line 176
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    const-wide/16 v4, 0x2710

    invoke-virtual {v0, v6, v4, v5}, Ljava/util/Timer;->schedule(Ljava/util/TimerTask;J)V

    .line 177
    new-instance v0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    move-object v1, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;ILjava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->sndRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    .line 178
    invoke-static {p1, p2}, Lcom/igg/sdk/IGGURLHelper;->getAppConfigURL(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x0

    const/16 v2, 0x2710

    new-instance v3, Lcom/igg/sdk/service/IGGAppConfigService$3;

    invoke-direct {v3, p0}, Lcom/igg/sdk/service/IGGAppConfigService$3;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;)V

    invoke-virtual {p0, v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGAppConfigService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;

    .line 190
    return-void
.end method


# virtual methods
.method public load(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 7
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "format"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    const/4 v2, 0x1

    .line 124
    new-instance v6, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;

    invoke-direct {v6, p0, v2}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigTask;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;I)V

    .line 125
    .local v6, "task":Ljava/util/TimerTask;
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    const-wide/16 v4, 0x1388

    invoke-virtual {v0, v6, v4, v5}, Ljava/util/Timer;->schedule(Ljava/util/TimerTask;J)V

    .line 126
    new-instance v0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    move-object v1, p0

    move-object v3, p1

    move-object v4, p2

    move-object v5, p3

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;ILjava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    .line 127
    sget-object v0, Lcom/igg/sdk/IGGSDKConstant$CDNType;->STATIC_ADDRESS:Lcom/igg/sdk/IGGSDKConstant$CDNType;

    invoke-static {p1, p2, v0}, Lcom/igg/sdk/IGGURLHelper;->getAppConfigURL(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/IGGSDKConstant$CDNType;)Ljava/lang/String;

    move-result-object v0

    const/4 v1, 0x0

    const/16 v2, 0x1388

    new-instance v3, Lcom/igg/sdk/service/IGGAppConfigService$1;

    invoke-direct {v3, p0}, Lcom/igg/sdk/service/IGGAppConfigService$1;-><init>(Lcom/igg/sdk/service/IGGAppConfigService;)V

    invoke-super {p0, v0, v1, v2, v3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService;->configRequestTask:Lcom/igg/util/AsyncTask;

    .line 138
    return-void
.end method
