.class Lcom/igg/util/EmulatorDetector$1;
.super Ljava/lang/Object;
.source "EmulatorDetector.java"

# interfaces
.implements Ljava/lang/Runnable;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/util/EmulatorDetector;->detect(Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/util/EmulatorDetector;

.field final synthetic val$pOnEmulatorDetectorListener:Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;


# direct methods
.method constructor <init>(Lcom/igg/util/EmulatorDetector;Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/util/EmulatorDetector;

    .prologue
    .line 167
    iput-object p1, p0, Lcom/igg/util/EmulatorDetector$1;->this$0:Lcom/igg/util/EmulatorDetector;

    iput-object p2, p0, Lcom/igg/util/EmulatorDetector$1;->val$pOnEmulatorDetectorListener:Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public run()V
    .locals 4

    .prologue
    .line 170
    iget-object v1, p0, Lcom/igg/util/EmulatorDetector$1;->this$0:Lcom/igg/util/EmulatorDetector;

    invoke-virtual {v1}, Lcom/igg/util/EmulatorDetector;->detect()Z

    move-result v0

    .line 171
    .local v0, "isEmulator":Z
    iget-object v1, p0, Lcom/igg/util/EmulatorDetector$1;->this$0:Lcom/igg/util/EmulatorDetector;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "This System is Emulator: "

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-static {v1, v2}, Lcom/igg/util/EmulatorDetector;->access$000(Lcom/igg/util/EmulatorDetector;Ljava/lang/String;)V

    .line 172
    iget-object v1, p0, Lcom/igg/util/EmulatorDetector$1;->val$pOnEmulatorDetectorListener:Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;

    if-eqz v1, :cond_0

    .line 173
    iget-object v1, p0, Lcom/igg/util/EmulatorDetector$1;->val$pOnEmulatorDetectorListener:Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;

    invoke-interface {v1, v0}, Lcom/igg/util/EmulatorDetector$OnEmulatorDetectorListener;->onResult(Z)V

    .line 175
    :cond_0
    return-void
.end method
