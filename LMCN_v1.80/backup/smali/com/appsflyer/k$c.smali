.class final Lcom/appsflyer/k$c;
.super Ljava/lang/Object;
.source ""


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/appsflyer/k;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = "c"
.end annotation


# instance fields
.field private final ˊ:Z

.field private final ˎ:Ljava/lang/String;


# direct methods
.method constructor <init>(Ljava/lang/String;Z)V
    .locals 0

    .prologue
    .line 26
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 27
    iput-object p1, p0, Lcom/appsflyer/k$c;->ˎ:Ljava/lang/String;

    .line 28
    iput-boolean p2, p0, Lcom/appsflyer/k$c;->ˊ:Z

    .line 29
    return-void
.end method


# virtual methods
.method public final ˏ()Ljava/lang/String;
    .locals 1

    .prologue
    .line 32
    iget-object v0, p0, Lcom/appsflyer/k$c;->ˎ:Ljava/lang/String;

    return-object v0
.end method

.method final ॱ()Z
    .locals 1

    .prologue
    .line 36
    iget-boolean v0, p0, Lcom/appsflyer/k$c;->ˊ:Z

    return v0
.end method
