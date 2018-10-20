.class Lcom/igg/sdk/service/IGGAppConfigService$1;
.super Ljava/lang/Object;
.source "IGGAppConfigService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeadersRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/sdk/service/IGGAppConfigService;->load(Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/sdk/service/IGGAppConfigService;


# direct methods
.method constructor <init>(Lcom/igg/sdk/service/IGGAppConfigService;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/sdk/service/IGGAppConfigService;

    .prologue
    .line 127
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfigService$1;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onHeadersRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;)V
    .locals 2
    .param p1, "error"    # Lcom/igg/sdk/error/IGGError;
    .param p3, "responseString"    # Ljava/lang/String;
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
            ")V"
        }
    .end annotation

    .prologue
    .line 130
    .local p2, "headerFieldsMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$1;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v0, v0, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    if-eqz v0, :cond_0

    .line 131
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v0

    const-string v1, "defaultRequestListener is not null"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 132
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$1;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v0, v0, Lcom/igg/sdk/service/IGGAppConfigService;->defaultRequestListener:Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;

    invoke-virtual {v0, p1, p2, p3}, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->onHeadersRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;)V

    .line 136
    :goto_0
    return-void

    .line 134
    :cond_0
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v0

    const-string v1, "defaultRequestListener is null"

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    goto :goto_0
.end method
