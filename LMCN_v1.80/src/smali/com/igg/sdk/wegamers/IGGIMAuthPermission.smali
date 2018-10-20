.class public Lcom/igg/sdk/wegamers/IGGIMAuthPermission;
.super Ljava/lang/Object;
.source "IGGIMAuthPermission.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;
    }
.end annotation


# static fields
.field private static final TAG:Ljava/lang/String; = "IGGIMAuthPermission"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getIMAuthCode(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;)V
    .locals 4
    .param p1, "gameId"    # Ljava/lang/String;
    .param p2, "IGGId"    # Ljava/lang/String;
    .param p3, "accesskey"    # Ljava/lang/String;
    .param p4, "appId"    # Ljava/lang/String;
    .param p5, "listener"    # Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;

    .prologue
    .line 28
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    .line 29
    .local v0, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v1, "app_id"

    invoke-virtual {v0, v1, p4}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 30
    const-string v1, "game_id"

    invoke-virtual {v0, v1, p1}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 31
    const-string v1, "igg_id"

    invoke-virtual {v0, v1, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 32
    const-string v1, "access_key"

    invoke-virtual {v0, v1, p3}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 34
    new-instance v1, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v1}, Lcom/igg/sdk/service/IGGService;-><init>()V

    const-string v2, "/permission/request"

    invoke-static {v2}, Lcom/igg/sdk/IGGURLHelper;->getWeChatAPI(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v2

    new-instance v3, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;

    invoke-direct {v3, p0, p5}, Lcom/igg/sdk/wegamers/IGGIMAuthPermission$1;-><init>(Lcom/igg/sdk/wegamers/IGGIMAuthPermission;Lcom/igg/sdk/wegamers/IGGIMAuthPermission$IGGIMAuthCodeListener;)V

    invoke-virtual {v1, v2, v0, v3}, Lcom/igg/sdk/service/IGGService;->CGIGetRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$CGIRequestListener;)V

    .line 62
    return-void
.end method
