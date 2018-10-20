.class public Lcom/igg/sdk/battle/IGGBattleRecordUploader;
.super Ljava/lang/Object;
.source "IGGBattleRecordUploader.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGBattleRecordUplader"


# instance fields
.field private gameId:Ljava/lang/String;

.field private httpUrl:Ljava/lang/String;

.field private retryTimes:I

.field private times:I


# direct methods
.method public constructor <init>(Ljava/lang/String;Lcom/igg/sdk/IGGStorage;)V
    .locals 1
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "storage"    # Lcom/igg/sdk/IGGStorage;

    .prologue
    const/4 v0, 0x0

    .line 63
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 28
    iput v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->retryTimes:I

    .line 29
    iput v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->times:I

    .line 64
    const-string v0, "push.php"

    invoke-virtual {p2, v0}, Lcom/igg/sdk/IGGStorage;->getAPIURL(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->httpUrl:Ljava/lang/String;

    .line 65
    iput-object p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->gameId:Ljava/lang/String;

    .line 66
    return-void
.end method

.method static synthetic access$000(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->times:I

    return v0
.end method

.method static synthetic access$002(Lcom/igg/sdk/battle/IGGBattleRecordUploader;I)I
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;
    .param p1, "x1"    # I

    .prologue
    .line 23
    iput p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->times:I

    return p1
.end method

.method static synthetic access$008(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I
    .locals 2
    .param p0, "x0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->times:I

    add-int/lit8 v1, v0, 0x1

    iput v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->times:I

    return v0
.end method

.method static synthetic access$100(Lcom/igg/sdk/battle/IGGBattleRecordUploader;)I
    .locals 1
    .param p0, "x0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;

    .prologue
    .line 23
    iget v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->retryTimes:I

    return v0
.end method

.method static synthetic access$200(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    .locals 0
    .param p0, "x0"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader;
    .param p1, "x1"    # Lcom/igg/sdk/battle/IGGBattleRecord;
    .param p2, "x2"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    .prologue
    .line 23
    invoke-direct {p0, p1, p2}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->uploadFileRequest(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    return-void
.end method

.method private uploadFileRequest(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    .locals 7
    .param p1, "recordFile"    # Lcom/igg/sdk/battle/IGGBattleRecord;
    .param p2, "listener"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;

    .prologue
    .line 126
    new-instance v5, Ljava/util/HashMap;

    invoke-direct {v5}, Ljava/util/HashMap;-><init>()V

    .line 127
    .local v5, "map":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v0, "g_id"

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->gameId:Ljava/lang/String;

    invoke-virtual {v5, v0, v1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 129
    new-instance v0, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService;-><init>()V

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->httpUrl:Ljava/lang/String;

    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getLocalFile()Ljava/io/File;

    move-result-object v2

    invoke-virtual {v2}, Ljava/io/File;->getPath()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->uniqueName()Ljava/lang/String;

    move-result-object v3

    const-string v4, "video"

    new-instance v6, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;

    invoke-direct {v6, p0, p1, p2}, Lcom/igg/sdk/battle/IGGBattleRecordUploader$1;-><init>(Lcom/igg/sdk/battle/IGGBattleRecordUploader;Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGService;->postFileRequest(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 183
    return-void
.end method


# virtual methods
.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 211
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getHttpUrl()Ljava/lang/String;
    .locals 1

    .prologue
    .line 200
    iget-object v0, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->httpUrl:Ljava/lang/String;

    return-object v0
.end method

.method public setRetryTimes(I)V
    .locals 0
    .param p1, "retryTimes"    # I

    .prologue
    .line 191
    iput p1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->retryTimes:I

    .line 192
    return-void
.end method

.method public upload(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V
    .locals 6
    .param p1, "recordFile"    # Lcom/igg/sdk/battle/IGGBattleRecord;
    .param p2, "listener"    # Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 80
    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->gameId:Ljava/lang/String;

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->gameId:Ljava/lang/String;

    const-string v2, ""

    invoke-virtual {v1, v2}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-eqz v1, :cond_1

    .line 81
    :cond_0
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "gameId is not null"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 82
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "gameId is not null"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 85
    :cond_1
    if-nez p1, :cond_2

    .line 86
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "recordFile is not null"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 87
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "recordFile is not null"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 90
    :cond_2
    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getLocalFile()Ljava/io/File;

    move-result-object v1

    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v1

    if-nez v1, :cond_3

    .line 91
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "recordFile is not exists"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 92
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "recordFile is not exists"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 95
    :cond_3
    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getBaseName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/String;->length()I

    move-result v1

    const/16 v2, 0x1b

    if-le v1, v2, :cond_4

    .line 96
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "recordFile name length is greater than 30"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 97
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "recordFile name length is greater than 30"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 100
    :cond_4
    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getBaseName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getBaseName()Ljava/lang/String;

    move-result-object v2

    const-string v3, "."

    invoke-virtual {v2, v3}, Ljava/lang/String;->lastIndexOf(Ljava/lang/String;)I

    move-result v2

    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getBaseName()Ljava/lang/String;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v3

    invoke-virtual {v1, v2, v3}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    .line 101
    .local v0, "fixBaseName":Ljava/lang/String;
    const-string v1, "IGGBattleRecordUplader"

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Filename suffix required"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 102
    const-string v1, ".gz"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v1

    if-nez v1, :cond_5

    .line 103
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "Filename suffix required .gz"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 104
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "Filename suffix required .gz"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 107
    :cond_5
    invoke-virtual {p1}, Lcom/igg/sdk/battle/IGGBattleRecord;->getLocalFile()Ljava/io/File;

    move-result-object v1

    invoke-virtual {v1}, Ljava/io/File;->length()J

    move-result-wide v2

    const-wide/32 v4, 0x100000

    cmp-long v1, v2, v4

    if-lez v1, :cond_6

    .line 108
    const-string v1, "IGGBattleRecordUplader"

    const-string v2, "recordFile File size is greater than 1M"

    invoke-static {v1, v2}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 109
    new-instance v1, Ljava/lang/Exception;

    const-string v2, "recordFile File size is greater than 1M"

    invoke-direct {v1, v2}, Ljava/lang/Exception;-><init>(Ljava/lang/String;)V

    throw v1

    .line 112
    :cond_6
    invoke-direct {p0, p1, p2}, Lcom/igg/sdk/battle/IGGBattleRecordUploader;->uploadFileRequest(Lcom/igg/sdk/battle/IGGBattleRecord;Lcom/igg/sdk/battle/IGGBattleRecordUploader$IGGBattleRecordUpladerListener;)V

    .line 113
    return-void
.end method
