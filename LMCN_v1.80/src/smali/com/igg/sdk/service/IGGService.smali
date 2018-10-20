.class public Lcom/igg/sdk/service/IGGService;
.super Ljava/lang/Object;
.source "IGGService.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/service/IGGService$CGIRequestListener;,
        Lcom/igg/sdk/service/IGGService$HeaderDelegate;,
        Lcom/igg/sdk/service/IGGService$HeadersRequestListener;,
        Lcom/igg/sdk/service/IGGService$DownloadRequestListener;,
        Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    }
.end annotation


# static fields
.field public static final CONNECTION_TIMEOUT_DELAY:I = 0x3a98

.field private static final CORE_POOL_SIZE:I

.field private static final CPU_COUNT:I

.field private static final KEEP_ALIVE:I = 0x1

.field private static final MAXIMUM_POOL_SIZE:I

.field public static final REMOTE_DATA_EMPTY_ERROR:I = 0x1f4

.field public static final REMOTE_DATA_FORMAT_ERROR:I = 0x1f5

.field public static final SO_TIMEOUT_DELAY:I = 0x3a98

.field public static final SYSTEM_NETWORK_ERROR:I = 0x190

.field private static final TAG:Ljava/lang/String; = "IGGService"

.field private static final THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

.field private static final sPoolWorkQueue:Ljava/util/concurrent/BlockingQueue;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/concurrent/BlockingQueue",
            "<",
            "Ljava/lang/Runnable;",
            ">;"
        }
    .end annotation
.end field

.field private static final sThreadFactory:Ljava/util/concurrent/ThreadFactory;


# direct methods
.method static constructor <clinit>()V
    .locals 9

    .prologue
    .line 53
    invoke-static {}, Ljava/lang/Runtime;->getRuntime()Ljava/lang/Runtime;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/Runtime;->availableProcessors()I

    move-result v0

    sput v0, Lcom/igg/sdk/service/IGGService;->CPU_COUNT:I

    .line 54
    sget v0, Lcom/igg/sdk/service/IGGService;->CPU_COUNT:I

    add-int/lit8 v0, v0, 0x1

    sput v0, Lcom/igg/sdk/service/IGGService;->CORE_POOL_SIZE:I

    .line 55
    sget v0, Lcom/igg/sdk/service/IGGService;->CPU_COUNT:I

    mul-int/lit8 v0, v0, 0x2

    add-int/lit8 v0, v0, 0x1

    sput v0, Lcom/igg/sdk/service/IGGService;->MAXIMUM_POOL_SIZE:I

    .line 57
    new-instance v0, Ljava/util/concurrent/LinkedBlockingQueue;

    const/16 v1, 0x80

    invoke-direct {v0, v1}, Ljava/util/concurrent/LinkedBlockingQueue;-><init>(I)V

    sput-object v0, Lcom/igg/sdk/service/IGGService;->sPoolWorkQueue:Ljava/util/concurrent/BlockingQueue;

    .line 58
    new-instance v0, Lcom/igg/sdk/service/IGGService$1;

    invoke-direct {v0}, Lcom/igg/sdk/service/IGGService$1;-><init>()V

    sput-object v0, Lcom/igg/sdk/service/IGGService;->sThreadFactory:Ljava/util/concurrent/ThreadFactory;

    .line 66
    new-instance v1, Ljava/util/concurrent/ThreadPoolExecutor;

    sget v2, Lcom/igg/sdk/service/IGGService;->CORE_POOL_SIZE:I

    sget v3, Lcom/igg/sdk/service/IGGService;->MAXIMUM_POOL_SIZE:I

    const-wide/16 v4, 0x1

    sget-object v6, Ljava/util/concurrent/TimeUnit;->SECONDS:Ljava/util/concurrent/TimeUnit;

    sget-object v7, Lcom/igg/sdk/service/IGGService;->sPoolWorkQueue:Ljava/util/concurrent/BlockingQueue;

    sget-object v8, Lcom/igg/sdk/service/IGGService;->sThreadFactory:Ljava/util/concurrent/ThreadFactory;

    invoke-direct/range {v1 .. v8}, Ljava/util/concurrent/ThreadPoolExecutor;-><init>(IIJLjava/util/concurrent/TimeUnit;Ljava/util/concurrent/BlockingQueue;Ljava/util/concurrent/ThreadFactory;)V

    sput-object v1, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public CGIGeneralGetRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 982
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$11;

    invoke-direct {v0, p0, p3}, Lcom/igg/sdk/service/IGGService$11;-><init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    invoke-virtual {p0, p1, p2, v0}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 1022
    return-void
.end method

.method public CGIGeneralRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 932
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$10;

    invoke-direct {v0, p0, p3}, Lcom/igg/sdk/service/IGGService$10;-><init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    invoke-virtual {p0, p1, p2, v0}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 972
    return-void
.end method

.method public CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 788
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x1

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 789
    return-void
.end method

.method protected CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "isFlatStruct"    # Z
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;Z",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 792
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$8;

    invoke-direct {v0, p0, p4, p3}, Lcom/igg/sdk/service/IGGService$8;-><init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;Z)V

    invoke-virtual {p0, p1, p2, v0}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 852
    return-void
.end method

.method public CGIGetRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 784
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 785
    return-void
.end method

.method public CGIRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 776
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x0

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 777
    return-void
.end method

.method protected CGIRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "isFlatStruct"    # Z
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;Z",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 862
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$9;

    invoke-direct {v0, p0, p4, p3}, Lcom/igg/sdk/service/IGGService$9;-><init>(Lcom/igg/sdk/service/IGGService;Lcom/igg/sdk/service/IGGService$CGIRequestListener;Z)V

    invoke-virtual {p0, p1, p2, v0}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 922
    return-void
.end method

.method public CGIRequestForFlatStruct(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$CGIRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$CGIRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 780
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/4 v0, 0x1

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->CGIRequest(Ljava/lang/String;Ljava/util/HashMap;ZLcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 781
    return-void
.end method

.method public DownloadFileRequest(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$DownloadRequestListener;)V
    .locals 6
    .param p1, "httpURL"    # Ljava/lang/String;
    .param p2, "fileName"    # Ljava/lang/String;
    .param p3, "path"    # Ljava/lang/String;
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$DownloadRequestListener;

    .prologue
    .line 1169
    new-instance v0, Lcom/igg/sdk/service/IGGService$13;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p3

    move-object v4, p2

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGService$13;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$DownloadRequestListener;)V

    .line 1258
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 1260
    return-void
.end method

.method public getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;
    .locals 6
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "timeOut"    # I
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$HeadersRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;I",
            "Lcom/igg/sdk/service/IGGService$HeadersRequestListener;",
            ")",
            "Lcom/igg/util/AsyncTask;"
        }
    .end annotation

    .prologue
    .line 309
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$4;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move v4, p3

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGService$4;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)V

    .line 419
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 421
    return-object v0
.end method

.method public getRequest(Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 8
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "connectTimeOut"    # I
    .param p4, "readTimeOut"    # I
    .param p5, "delegate"    # Lcom/igg/sdk/service/IGGService$HeaderDelegate;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;II",
            "Lcom/igg/sdk/service/IGGService$HeaderDelegate;",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 195
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$3;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move v4, p3

    move v5, p4

    move-object v6, p5

    move-object v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/sdk/service/IGGService$3;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 285
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 287
    return-void
.end method

.method public getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 5
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 109
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$2;

    invoke-direct {v0, p0, p1, p2, p3}, Lcom/igg/sdk/service/IGGService$2;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 186
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 188
    return-void
.end method

.method public getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 7
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "delegate"    # Lcom/igg/sdk/service/IGGService$HeaderDelegate;
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$HeaderDelegate;",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v3, 0x3a98

    .line 191
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move v4, v3

    move-object v5, p3

    move-object v6, p4

    invoke-virtual/range {v0 .. v6}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;IILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 192
    return-void
.end method

.method public getRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$HeadersRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$HeadersRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 299
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v0, 0x3a98

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->getRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeadersRequestListener;)Lcom/igg/util/AsyncTask;

    .line 300
    return-void
.end method

.method public postFileRequest(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 8
    .param p1, "URL"    # Ljava/lang/String;
    .param p2, "pathToOurFile"    # Ljava/lang/String;
    .param p3, "newFileName"    # Ljava/lang/String;
    .param p4, "fileParameterName"    # Ljava/lang/String;
    .param p6, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 1033
    .local p5, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$12;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p5

    move-object v4, p2

    move-object v5, p4

    move-object v6, p3

    move-object v7, p6

    invoke-direct/range {v0 .. v7}, Lcom/igg/sdk/service/IGGService$12;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;Ljava/util/HashMap;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 1156
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 1158
    return-void
.end method

.method public postJSONRequest(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 6
    .param p1, "URL"    # Ljava/lang/String;
    .param p2, "parameter"    # Ljava/lang/String;
    .param p3, "connectionTimeOut"    # I
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    .prologue
    .line 680
    new-instance v0, Lcom/igg/sdk/service/IGGService$7;

    move-object v1, p0

    move-object v2, p1

    move v3, p3

    move-object v4, p2

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGService$7;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;ILjava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 767
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 769
    return-void
.end method

.method public postJSONRequest(Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p2, "jsonString"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;

    .prologue
    .line 668
    const/16 v0, 0x3a98

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->postJSONRequest(Ljava/lang/String;Ljava/lang/String;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 669
    return-void
.end method

.method public postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 6
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "timeOut"    # I
    .param p4, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;I",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 557
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$6;

    move-object v1, p0

    move-object v2, p1

    move v3, p3

    move-object v4, p2

    move-object v5, p4

    invoke-direct/range {v0 .. v5}, Lcom/igg/sdk/service/IGGService$6;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;ILjava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 652
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 654
    return-void
.end method

.method public postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$HeaderDelegate;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V
    .locals 7
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "timeOut"    # I
    .param p4, "delegate"    # Lcom/igg/sdk/service/IGGService$HeaderDelegate;
    .param p5, "listener"    # Lcom/igg/sdk/service/IGGService$HeadersRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;I",
            "Lcom/igg/sdk/service/IGGService$HeaderDelegate;",
            "Lcom/igg/sdk/service/IGGService$HeadersRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 432
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    new-instance v0, Lcom/igg/sdk/service/IGGService$5;

    move-object v1, p0

    move-object v2, p1

    move v3, p3

    move-object v4, p4

    move-object v5, p2

    move-object v6, p5

    invoke-direct/range {v0 .. v6}, Lcom/igg/sdk/service/IGGService$5;-><init>(Lcom/igg/sdk/service/IGGService;Ljava/lang/String;ILcom/igg/sdk/service/IGGService$HeaderDelegate;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$HeadersRequestListener;)V

    .line 552
    .local v0, "task":Lcom/igg/util/AsyncTask;, "Lcom/igg/util/AsyncTask<Ljava/lang/Object;Ljava/lang/Integer;Ljava/lang/Object;>;"
    sget-object v2, Lcom/igg/sdk/service/IGGService;->THREAD_POOL_EXECUTOR:Ljava/util/concurrent/Executor;

    const/4 v1, 0x1

    new-array v3, v1, [Ljava/lang/Object;

    const/4 v4, 0x0

    const/4 v1, 0x0

    check-cast v1, Ljava/lang/Void;

    aput-object v1, v3, v4

    invoke-virtual {v0, v2, v3}, Lcom/igg/util/AsyncTask;->executeOnExecutor(Ljava/util/concurrent/Executor;[Ljava/lang/Object;)Lcom/igg/util/AsyncTask;

    .line 554
    return-void
.end method

.method public postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V
    .locals 1
    .param p1, "URL"    # Ljava/lang/String;
    .param p3, "listener"    # Lcom/igg/sdk/service/IGGService$GeneralRequestListener;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/HashMap",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/String;",
            ">;",
            "Lcom/igg/sdk/service/IGGService$GeneralRequestListener;",
            ")V"
        }
    .end annotation

    .prologue
    .line 664
    .local p2, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const/16 v0, 0x3a98

    invoke-virtual {p0, p1, p2, v0, p3}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;ILcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    .line 665
    return-void
.end method
