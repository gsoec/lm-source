.class final Lcom/alipay/sdk/app/PayTask$a;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/alipay/sdk/app/PayTask;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x2
    name = "a"
.end annotation


# instance fields
.field a:Ljava/lang/String;

.field b:Ljava/lang/String;

.field final synthetic c:Lcom/alipay/sdk/app/PayTask;


# direct methods
.method private constructor <init>(Lcom/alipay/sdk/app/PayTask;)V
    .locals 1

    .prologue
    .line 280
    iput-object p1, p0, Lcom/alipay/sdk/app/PayTask$a;->c:Lcom/alipay/sdk/app/PayTask;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 281
    const-string v0, ""

    iput-object v0, p0, Lcom/alipay/sdk/app/PayTask$a;->a:Ljava/lang/String;

    .line 282
    const-string v0, ""

    iput-object v0, p0, Lcom/alipay/sdk/app/PayTask$a;->b:Ljava/lang/String;

    return-void
.end method

.method synthetic constructor <init>(Lcom/alipay/sdk/app/PayTask;B)V
    .locals 0

    .prologue
    .line 280
    invoke-direct {p0, p1}, Lcom/alipay/sdk/app/PayTask$a;-><init>(Lcom/alipay/sdk/app/PayTask;)V

    return-void
.end method

.method private a()Ljava/lang/String;
    .locals 1

    .prologue
    .line 285
    iget-object v0, p0, Lcom/alipay/sdk/app/PayTask$a;->a:Ljava/lang/String;

    return-object v0
.end method

.method private a(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 289
    iput-object p1, p0, Lcom/alipay/sdk/app/PayTask$a;->a:Ljava/lang/String;

    .line 290
    return-void
.end method

.method private b()Ljava/lang/String;
    .locals 1

    .prologue
    .line 293
    iget-object v0, p0, Lcom/alipay/sdk/app/PayTask$a;->b:Ljava/lang/String;

    return-object v0
.end method

.method private b(Ljava/lang/String;)V
    .locals 0

    .prologue
    .line 297
    iput-object p1, p0, Lcom/alipay/sdk/app/PayTask$a;->b:Ljava/lang/String;

    .line 298
    return-void
.end method
