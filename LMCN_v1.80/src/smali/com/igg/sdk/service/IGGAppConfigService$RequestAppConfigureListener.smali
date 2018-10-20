.class Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;
.super Ljava/lang/Object;
.source "IGGAppConfigService.java"

# interfaces
.implements Lcom/igg/sdk/service/IGGService$HeadersRequestListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/sdk/service/IGGAppConfigService;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "RequestAppConfigureListener"
.end annotation


# instance fields
.field private appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

.field private format:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

.field private name:Ljava/lang/String;

.field final synthetic this$0:Lcom/igg/sdk/service/IGGAppConfigService;

.field private type:I


# direct methods
.method public constructor <init>(Lcom/igg/sdk/service/IGGAppConfigService;ILjava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V
    .locals 0
    .param p2, "type"    # I
    .param p3, "name"    # Ljava/lang/String;
    .param p4, "format"    # Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .param p5, "appConfigListener"    # Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .prologue
    .line 201
    iput-object p1, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 202
    iput p2, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->type:I

    .line 203
    iput-object p3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->name:Ljava/lang/String;

    .line 204
    iput-object p4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->format:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    .line 205
    iput-object p5, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    .line 206
    return-void
.end method


# virtual methods
.method public getAppConfigListener()Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;
    .locals 1

    .prologue
    .line 268
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    return-object v0
.end method

.method public getFormat()Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;
    .locals 1

    .prologue
    .line 272
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->format:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    return-object v0
.end method

.method public getName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 276
    iget-object v0, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->name:Ljava/lang/String;

    return-object v0
.end method

.method public onHeadersRequestFinished(Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;)V
    .locals 7
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
    .local p2, "headerFieldsMap":Ljava/util/Map;, "Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;"
    const/4 v5, 0x1

    .line 210
    invoke-static {}, Lcom/igg/sdk/service/IGGAppConfigService;->access$000()Ljava/lang/String;

    move-result-object v3

    const-string v4, "timer.cancel"

    invoke-static {v3, v4}, Landroid/util/Log;->e(Ljava/lang/String;Ljava/lang/String;)I

    .line 211
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v3, v3, Lcom/igg/sdk/service/IGGAppConfigService;->timer:Ljava/util/Timer;

    invoke-virtual {v3}, Ljava/util/Timer;->cancel()V

    .line 212
    const/4 v2, 0x0

    .line 213
    .local v2, "ok":I
    iget v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->type:I

    packed-switch v3, :pswitch_data_0

    .line 265
    :goto_0
    return-void

    .line 215
    :pswitch_0
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v3

    if-eqz v3, :cond_0

    if-eqz p3, :cond_0

    const-string v3, ""

    invoke-virtual {p3, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_0

    .line 216
    const-string v3, "X-IGG"

    invoke-interface {p2, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/List;

    .line 217
    .local v1, "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    if-eqz v1, :cond_0

    .line 218
    const/4 v2, 0x1

    .line 222
    .end local v1    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    :cond_0
    if-ne v2, v5, :cond_1

    .line 223
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {v3, p1, p2, p3, v4}, Lcom/igg/sdk/service/IGGAppConfigService;->access$400(Lcom/igg/sdk/service/IGGAppConfigService;Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    goto :goto_0

    .line 225
    :cond_1
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->name:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->format:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    iget-object v6, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {v3, v4, v5, v6}, Lcom/igg/sdk/service/IGGAppConfigService;->access$100(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    goto :goto_0

    .line 230
    :pswitch_1
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v3

    if-eqz v3, :cond_2

    if-eqz p3, :cond_2

    const-string v3, ""

    invoke-virtual {p3, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_2

    .line 231
    const-string v3, "X-IGG"

    invoke-interface {p2, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/List;

    .line 232
    .restart local v1    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    if-eqz v1, :cond_2

    .line 233
    const/4 v2, 0x1

    .line 237
    .end local v1    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    :cond_2
    if-ne v2, v5, :cond_3

    .line 238
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {v3, p1, p2, p3, v4}, Lcom/igg/sdk/service/IGGAppConfigService;->access$400(Lcom/igg/sdk/service/IGGAppConfigService;Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    goto :goto_0

    .line 240
    :cond_3
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->name:Ljava/lang/String;

    iget-object v5, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->format:Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;

    iget-object v6, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {v3, v4, v5, v6}, Lcom/igg/sdk/service/IGGAppConfigService;->access$200(Lcom/igg/sdk/service/IGGAppConfigService;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGAppConfigContentFormat;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    goto :goto_0

    .line 245
    :pswitch_2
    invoke-virtual {p1}, Lcom/igg/sdk/error/IGGError;->isNone()Z

    move-result v3

    if-eqz v3, :cond_4

    if-eqz p3, :cond_4

    const-string v3, ""

    invoke-virtual {p3, v3}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v3

    if-nez v3, :cond_4

    .line 246
    const-string v3, "X-IGG"

    invoke-interface {p2, v3}, Ljava/util/Map;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/util/List;

    .line 247
    .restart local v1    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    if-eqz v1, :cond_4

    .line 248
    const/4 v2, 0x1

    .line 252
    .end local v1    # "headerList":Ljava/util/List;, "Ljava/util/List<Ljava/lang/String;>;"
    :cond_4
    if-ne v2, v5, :cond_5

    .line 253
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    iget-object v4, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {v3, p1, p2, p3, v4}, Lcom/igg/sdk/service/IGGAppConfigService;->access$400(Lcom/igg/sdk/service/IGGAppConfigService;Lcom/igg/sdk/error/IGGError;Ljava/util/Map;Ljava/lang/String;Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;)V

    goto/16 :goto_0

    .line 255
    :cond_5
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->this$0:Lcom/igg/sdk/service/IGGAppConfigService;

    invoke-static {v3}, Lcom/igg/sdk/service/IGGAppConfigService;->access$300(Lcom/igg/sdk/service/IGGAppConfigService;)Lcom/igg/sdk/bean/IGGAppConfig;

    move-result-object v0

    .line 256
    .local v0, "appConfig":Lcom/igg/sdk/bean/IGGAppConfig;
    if-eqz v0, :cond_6

    .line 257
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    invoke-static {}, Lcom/igg/sdk/error/IGGError;->NoneError()Lcom/igg/sdk/error/IGGError;

    move-result-object v4

    invoke-interface {v3, v4, v0}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;->onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V

    goto/16 :goto_0

    .line 259
    :cond_6
    iget-object v3, p0, Lcom/igg/sdk/service/IGGAppConfigService$RequestAppConfigureListener;->appConfigListener:Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;

    const/4 v4, 0x0

    invoke-interface {v3, p1, v4}, Lcom/igg/sdk/service/IGGAppConfigService$AppConfigListener;->onAppConfigLoadFinished(Lcom/igg/sdk/error/IGGError;Lcom/igg/sdk/bean/IGGAppConfig;)V

    goto/16 :goto_0

    .line 213
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
    .end packed-switch
.end method
